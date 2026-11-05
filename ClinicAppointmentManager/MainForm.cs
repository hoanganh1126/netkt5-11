using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ClinicAppointmentManager
{
    public partial class MainForm : Form
    {
        private static readonly string[] Statuses = { "Chờ khám", "Đang khám", "Hoàn tất", "Đã hủy" };
        private static readonly string[] Doctors =
        {
            "BS. Nguyễn Văn An", "BS. Trần Thị Bình", "BS. Lê Minh Châu", "BS. Phạm Quốc Dũng"
        };

        // SĐT Việt Nam: 0xxxxxxxxx (10 số) hoặc +84xxxxxxxxx
        private static readonly Regex PhoneRegex = new Regex(@"^(0\d{9}|\+84\d{9})$");

        private readonly BindingList<Appointment> _all = new BindingList<Appointment>();   // toàn bộ dữ liệu
        private readonly BindingList<Appointment> _view = new BindingList<Appointment>();  // dữ liệu sau khi lọc (gắn vào lưới)

        private Appointment _selected;     // lịch hẹn đang được chọn trên lưới
        private bool _suppress;            // tạm tắt xử lý SelectionChanged khi nạp lại lưới
        private Control _firstInvalid;     // control lỗi đầu tiên để focus

        public MainForm()
        {
            InitializeComponent();

            cboDoctor.Items.AddRange(Doctors);
            cboStatus.Items.AddRange(Statuses);
            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.AddRange(Statuses);
            cboFilterStatus.SelectedIndex = 0;
            dtpFilterDate.Value = DateTime.Today;

            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSource1.DataSource = _view;
            dgvAppointments.DataSource = bindingSource1;

            SeedData();
            ApplyFilter();
            ClearForm();
        }

        // ---------------------------------------------------------------- Dữ liệu mẫu
        private void SeedData()
        {
            DateTime d = DateTime.Today;
            _all.Add(new Appointment { Id = "LH001", PatientName = "Nguyễn Thị Lan", Phone = "0912345678", AppointmentTime = d.AddHours(8).AddMinutes(30), Doctor = Doctors[0], Reason = "Khám tổng quát", Status = "Hoàn tất" });
            _all.Add(new Appointment { Id = "LH002", PatientName = "Trần Văn Hùng", Phone = "0987654321", AppointmentTime = d.AddHours(9), Doctor = Doctors[1], Reason = "Đau đầu kéo dài", Status = "Đang khám" });
            _all.Add(new Appointment { Id = "LH003", PatientName = "Lê Hoàng Nam", Phone = "0903111222", AppointmentTime = d.AddHours(23), Doctor = Doctors[2], Reason = "Tái khám tim mạch", Status = "Chờ khám" });
            _all.Add(new Appointment { Id = "LH004", PatientName = "Phạm Thu Hà", Phone = "0977888999", AppointmentTime = d.AddDays(1).AddHours(10), Doctor = Doctors[3], Reason = "Khám da liễu", Status = "Chờ khám" });
            _all.Add(new Appointment { Id = "LH005", PatientName = "Vũ Đức Anh", Phone = "+84935123456", AppointmentTime = d.AddDays(2).AddHours(14), Doctor = Doctors[0], Reason = "Đau dạ dày", Status = "Đã hủy" });
        }

        // ---------------------------------------------------------------- Lọc / tìm kiếm
        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            chkFilterDate.Checked = false;
            cboFilterStatus.SelectedIndex = 0;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string kw = txtSearch.Text.Trim();
            string kwPhone = NormalizePhone(kw);
            bool byDate = chkFilterDate.Checked;
            DateTime date = dtpFilterDate.Value.Date;
            string status = cboFilterStatus.SelectedIndex > 0 ? (string)cboFilterStatus.SelectedItem : null;

            var result = _all.Where(a =>
                    (kw.Length == 0
                        || a.PatientName.Contains(kw, StringComparison.CurrentCultureIgnoreCase)
                        || (kwPhone.Length > 0 && a.Phone.Contains(kwPhone)))
                    && (!byDate || a.AppointmentTime.Date == date)
                    && (status == null || a.Status == status))
                .OrderBy(a => a.AppointmentTime)
                .ToList();

            Appointment prev = _selected;
            _suppress = true;
            try
            {
                _view.RaiseListChangedEvents = false;
                _view.Clear();
                foreach (var a in result) _view.Add(a);
                _view.RaiseListChangedEvents = true;
                _view.ResetBindings();

                dgvAppointments.ClearSelection();
                _selected = null;
                if (prev != null)
                {
                    int idx = _view.IndexOf(prev);
                    if (idx >= 0)
                    {
                        dgvAppointments.Rows[idx].Selected = true;
                        dgvAppointments.CurrentCell = dgvAppointments.Rows[idx].Cells[0];
                        _selected = prev;
                    }
                }
            }
            finally
            {
                _suppress = false;
            }
            UpdateStatusBar();
        }

        private void UpdateStatusBar()
        {
            lblStatusCount.Text = "Số lịch hẹn sau khi lọc: " + _view.Count + " / " + _all.Count;
        }

        // ---------------------------------------------------------------- Chọn dòng -> nạp lên form
        private void dgvAppointments_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppress || dgvAppointments.SelectedRows.Count == 0) return;
            var a = dgvAppointments.SelectedRows[0].DataBoundItem as Appointment;
            if (a == null) return;

            _selected = a;
            errorProvider1.Clear();
            txtId.Text = a.Id;
            txtName.Text = a.PatientName;
            txtPhone.Text = a.Phone;
            dtpAppointment.Value = a.AppointmentTime;
            cboDoctor.SelectedItem = a.Doctor;
            cboStatus.SelectedItem = a.Status;
            txtReason.Text = a.Reason;
        }

        // ---------------------------------------------------------------- Thêm / Cập nhật / Xóa
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            if (MessageBox.Show("Bạn có chắc muốn thêm lịch hẹn này?", "Xác nhận thêm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var a = new Appointment();
            ReadForm(a);
            _all.Add(a);
            _selected = null;
            ApplyFilter();
            ClearForm();
            MessageBox.Show("Đã thêm lịch hẹn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn trên bảng để cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput(_selected)) return;

            if (MessageBox.Show("Bạn có chắc muốn cập nhật lịch hẹn \"" + _selected.Id + "\"?", "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            ReadForm(_selected);
            ApplyFilter();   // làm mới bảng + số lượng trên StatusStrip
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một lịch hẹn trên bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa lịch hẹn \"" + _selected.Id + "\" của " + _selected.PatientName + "?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            _all.Remove(_selected);
            _selected = null;
            ApplyFilter();
            ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selected = null;
            errorProvider1.Clear();
            dgvAppointments.ClearSelection();
            txtId.Text = NextId();
            txtName.Text = "";
            txtPhone.Text = "";
            dtpAppointment.Value = TruncateToMinute(DateTime.Now.AddHours(1));
            cboDoctor.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            txtReason.Text = "";
            txtName.Focus();
        }

        private string NextId()
        {
            int n = _all.Count + 1;
            string id;
            do { id = "LH" + n.ToString("D3"); n++; } while (_all.Any(a => a.Id == id));
            return id;
        }

        private void ReadForm(Appointment a)
        {
            a.Id = txtId.Text.Trim();
            a.PatientName = txtName.Text.Trim();
            a.Phone = NormalizePhone(txtPhone.Text);
            a.AppointmentTime = TruncateToMinute(dtpAppointment.Value);
            a.Doctor = (string)cboDoctor.SelectedItem;
            a.Status = (string)cboStatus.SelectedItem;
            a.Reason = txtReason.Text.Trim();
        }

        // ---------------------------------------------------------------- Kiểm tra dữ liệu (ErrorProvider)
        private void SetError(Control c, string message)
        {
            errorProvider1.SetError(c, message);
            if (_firstInvalid == null) _firstInvalid = c;
        }

        private bool ValidateInput(Appointment editing)
        {
            errorProvider1.Clear();
            _firstInvalid = null;

            string id = txtId.Text.Trim();
            if (id.Length == 0)
                SetError(txtId, "Mã lịch hẹn không được để trống.");
            else if (_all.Any(a => !ReferenceEquals(a, editing) && string.Equals(a.Id, id, StringComparison.OrdinalIgnoreCase)))
                SetError(txtId, "Mã lịch hẹn đã tồn tại.");

            if (txtName.Text.Trim().Length == 0)
                SetError(txtName, "Họ tên bệnh nhân không được để trống.");

            string phone = NormalizePhone(txtPhone.Text);
            if (phone.Length == 0)
                SetError(txtPhone, "Số điện thoại không được để trống.");
            else if (!PhoneRegex.IsMatch(phone))
                SetError(txtPhone, "Số điện thoại không hợp lệ (VD: 0912345678 hoặc +84912345678).");

            if (cboDoctor.SelectedIndex < 0)
                SetError(cboDoctor, "Vui lòng chọn bác sĩ.");

            if (cboStatus.SelectedIndex < 0)
                SetError(cboStatus, "Vui lòng chọn trạng thái.");

            if (txtReason.Text.Trim().Length == 0)
                SetError(txtReason, "Lý do khám không được để trống.");

            // Ngày hẹn không được ở quá khứ (khi sửa: chỉ kiểm tra nếu người dùng đổi ngày giờ)
            DateTime dt = TruncateToMinute(dtpAppointment.Value);
            bool changed = editing == null || editing.AppointmentTime != dt;
            if (changed && dt < TruncateToMinute(DateTime.Now))
                SetError(dtpAppointment, "Ngày giờ hẹn không được nằm trong quá khứ.");

            if (_firstInvalid != null)
            {
                _firstInvalid.Focus();
                return false;
            }
            return true;
        }

        private static string NormalizePhone(string s)
        {
            return Regex.Replace(s ?? "", @"[\s.\-()]", "");
        }

        private static DateTime TruncateToMinute(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, 0);
        }

        // ---------------------------------------------------------------- Xuất CSV
        private void mnuExportCsv_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "lich_hen_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Mã lịch hẹn,Họ tên bệnh nhân,Số điện thoại,Ngày giờ hẹn,Bác sĩ,Lý do khám,Trạng thái");
                foreach (var a in _view)
                {
                    sb.AppendLine(string.Join(",",
                        Csv(a.Id),
                        Csv(a.PatientName),
                        Csv("=\"" + a.Phone + "\""),   // giữ số 0 đầu khi mở bằng Excel
                        Csv(a.AppointmentTime.ToString("dd/MM/yyyy HH:mm")),
                        Csv(a.Doctor),
                        Csv(a.Reason),
                        Csv(a.Status)));
                }
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã xuất " + _view.Count + " lịch hẹn ra tệp:\n" + saveFileDialog1.FileName,
                    "Xuất CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể ghi tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string Csv(string s)
        {
            if (s == null) return "\"\"";
            return "\"" + s.Replace("\"", "\"\"") + "\"";
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
