using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabEquipmentCheckout
{
    public partial class MainForm : Form
    {
        private static readonly string[] Equipments =
        {
            "Máy chiếu", "Laptop", "Oscilloscope", "Đồng hồ vạn năng",
            "Bộ Arduino Uno", "Raspberry Pi 4", "Router Cisco", "Bộ hàn thiếc"
        };

        private readonly BindingList<CheckoutRecord> _all = new BindingList<CheckoutRecord>();   // toàn bộ phiếu
        private readonly BindingList<CheckoutRecord> _view = new BindingList<CheckoutRecord>();  // phiếu sau khi lọc (gắn vào lưới)

        private CheckoutRecord _selected;
        private bool _suppress;
        private Control _firstInvalid;

        public MainForm()
        {
            InitializeComponent();

            cboEquipment.Items.AddRange(Equipments);
            cboFilterStatus.Items.AddRange(new object[] { "Tất cả", CheckoutRecord.StatusBorrowing, CheckoutRecord.StatusOverdue, CheckoutRecord.StatusReturned });
            cboFilterStatus.SelectedIndex = 0;

            dgvRecords.AutoGenerateColumns = false;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSource1.DataSource = _view;
            dgvRecords.DataSource = bindingSource1;

            SeedData();
            ApplyFilter();
            ClearForm();
        }

        // ---------------------------------------------------------------- Dữ liệu mẫu
        private void SeedData()
        {
            DateTime t = DateTime.Today;
            _all.Add(new CheckoutRecord { Id = "PM001", StudentId = "SV2021001", StudentName = "Nguyễn Văn An", Equipment = "Laptop", Quantity = 1, BorrowDate = t.AddDays(-10), DueDate = t.AddDays(-3) });                              // quá hạn
            _all.Add(new CheckoutRecord { Id = "PM002", StudentId = "SV2021002", StudentName = "Trần Thị Bình", Equipment = "Oscilloscope", Quantity = 2, BorrowDate = t.AddDays(-2), DueDate = t.AddDays(5) });                  // đang mượn
            _all.Add(new CheckoutRecord { Id = "PM003", StudentId = "SV2021003", StudentName = "Lê Minh Châu", Equipment = "Bộ Arduino Uno", Quantity = 3, BorrowDate = t.AddDays(-15), DueDate = t.AddDays(-8), ReturnDate = t.AddDays(-9) }); // đã trả
            _all.Add(new CheckoutRecord { Id = "PM004", StudentId = "SV2021004", StudentName = "Phạm Quốc Dũng", Equipment = "Máy chiếu", Quantity = 1, BorrowDate = t.AddDays(-7), DueDate = t.AddDays(-1) });                      // quá hạn
            _all.Add(new CheckoutRecord { Id = "PM005", StudentId = "SV2021005", StudentName = "Hoàng Thu Hà", Equipment = "Raspberry Pi 4", Quantity = 1, BorrowDate = t, DueDate = t.AddDays(7) });                           // đang mượn
        }

        // ---------------------------------------------------------------- Lọc / tìm kiếm
        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboFilterStatus.SelectedIndex = 0;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string kw = txtSearch.Text.Trim();
            string status = cboFilterStatus.SelectedIndex > 0 ? (string)cboFilterStatus.SelectedItem : null;

            var result = _all.Where(r =>
                    (kw.Length == 0
                        || r.StudentId.Contains(kw, StringComparison.CurrentCultureIgnoreCase)
                        || r.Equipment.Contains(kw, StringComparison.CurrentCultureIgnoreCase))
                    && (status == null || r.Status == status))
                .ToList();

            CheckoutRecord prev = _selected;
            _suppress = true;
            try
            {
                _view.RaiseListChangedEvents = false;
                _view.Clear();
                foreach (var r in result) _view.Add(r);
                _view.RaiseListChangedEvents = true;
                _view.ResetBindings();

                dgvRecords.ClearSelection();
                _selected = null;
                if (prev != null)
                {
                    int idx = _view.IndexOf(prev);
                    if (idx >= 0)
                    {
                        dgvRecords.Rows[idx].Selected = true;
                        dgvRecords.CurrentCell = dgvRecords.Rows[idx].Cells[0];
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
            lblTotal.Text = "Tổng số phiếu: " + _all.Count;
            lblOverdue.Text = "Quá hạn: " + _all.Count(r => r.Status == CheckoutRecord.StatusOverdue);
            lblShown.Text = "Đang hiển thị: " + _view.Count;
        }

        // Tô đỏ các phiếu quá hạn
        private void dgvRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _view.Count) return;
            bool overdue = _view[e.RowIndex].Status == CheckoutRecord.StatusOverdue;
            dgvRecords.Rows[e.RowIndex].DefaultCellStyle.ForeColor = overdue ? Color.Firebrick : Color.Empty;
        }

        // ---------------------------------------------------------------- Chọn dòng -> nạp lên form
        private void dgvRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppress || dgvRecords.SelectedRows.Count == 0) return;
            var r = dgvRecords.SelectedRows[0].DataBoundItem as CheckoutRecord;
            if (r == null) return;
            _selected = r;
            LoadToForm(r);
        }

        private void LoadToForm(CheckoutRecord r)
        {
            errorProvider1.Clear();
            txtId.Text = r.Id;
            txtStudentId.Text = r.StudentId;
            txtStudentName.Text = r.StudentName;
            cboEquipment.SelectedItem = r.Equipment;
            nudQuantity.Value = Math.Min(Math.Max(r.Quantity, nudQuantity.Minimum), nudQuantity.Maximum);
            dtpBorrow.Value = r.BorrowDate;
            dtpDue.Value = r.DueDate;
            if (r.ReturnDate.HasValue)
            {
                dtpReturn.Value = r.ReturnDate.Value;
                dtpReturn.Checked = true;
            }
            else
            {
                dtpReturn.Checked = false;
            }
            RefreshStatusPreview();
        }

        private void DateFields_Changed(object sender, EventArgs e)
        {
            RefreshStatusPreview();
        }

        /// <summary>Hiển thị tình trạng tự động theo hạn trả / ngày trả đang nhập.</summary>
        private void RefreshStatusPreview()
        {
            DateTime? ret = dtpReturn.Checked ? dtpReturn.Value.Date : (DateTime?)null;
            txtStatus.Text = CheckoutRecord.ComputeStatus(dtpDue.Value.Date, ret);
        }

        // ---------------------------------------------------------------- Thêm / Cập nhật / Xóa / Đánh dấu đã trả
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            if (MessageBox.Show("Bạn có chắc muốn thêm phiếu mượn này?", "Xác nhận thêm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var r = new CheckoutRecord();
            ReadForm(r);
            _all.Add(r);
            _selected = null;
            ApplyFilter();
            ClearForm();
            MessageBox.Show("Đã thêm phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu trên bảng để cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput(_selected)) return;

            if (MessageBox.Show("Bạn có chắc muốn cập nhật phiếu \"" + _selected.Id + "\"?", "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            ReadForm(_selected);
            ApplyFilter();
            if (_selected != null) LoadToForm(_selected);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu trên bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa phiếu \"" + _selected.Id + "\"?", "Xác nhận xóa",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            _all.Remove(_selected);
            _selected = null;
            ApplyFilter();
            ClearForm();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một phiếu trên bảng để đánh dấu đã trả.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_selected.ReturnDate.HasValue)
            {
                MessageBox.Show("Phiếu này đã được trả vào ngày " + _selected.ReturnDate.Value.ToString("dd/MM/yyyy") + ".",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime today = DateTime.Today;
            if (today < _selected.BorrowDate.Date)
            {
                MessageBox.Show("Ngày trả thực tế không được trước ngày mượn.", "Không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xác nhận phiếu \"" + _selected.Id + "\" đã được trả hôm nay (" + today.ToString("dd/MM/yyyy") + ")?",
                    "Xác nhận trả thiết bị", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _selected.ReturnDate = today;   // cập nhật ngày trả thực tế -> trạng thái tự chuyển "Đã trả"
            ApplyFilter();
            if (_selected != null) LoadToForm(_selected); else ClearForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            _selected = null;
            errorProvider1.Clear();
            dgvRecords.ClearSelection();
            txtId.Text = NextId();
            txtStudentId.Text = "";
            txtStudentName.Text = "";
            cboEquipment.SelectedIndex = -1;
            nudQuantity.Value = 1;
            dtpBorrow.Value = DateTime.Today;
            dtpDue.Value = DateTime.Today.AddDays(7);
            dtpReturn.Value = DateTime.Today;
            dtpReturn.Checked = false;
            RefreshStatusPreview();
            txtStudentId.Focus();
        }

        private string NextId()
        {
            int n = _all.Count + 1;
            string id;
            do { id = "PM" + n.ToString("D3"); n++; } while (_all.Any(r => r.Id == id));
            return id;
        }

        private void ReadForm(CheckoutRecord r)
        {
            r.Id = txtId.Text.Trim();
            r.StudentId = txtStudentId.Text.Trim();
            r.StudentName = txtStudentName.Text.Trim();
            r.Equipment = (string)cboEquipment.SelectedItem;
            r.Quantity = (int)nudQuantity.Value;
            r.BorrowDate = dtpBorrow.Value.Date;
            r.DueDate = dtpDue.Value.Date;
            r.ReturnDate = dtpReturn.Checked ? dtpReturn.Value.Date : (DateTime?)null;
        }

        // ---------------------------------------------------------------- Kiểm tra dữ liệu (ErrorProvider)
        private void SetError(Control c, string message)
        {
            errorProvider1.SetError(c, message);
            if (_firstInvalid == null) _firstInvalid = c;
        }

        private bool ValidateInput(CheckoutRecord editing)
        {
            errorProvider1.Clear();
            _firstInvalid = null;

            string id = txtId.Text.Trim();
            if (id.Length == 0)
                SetError(txtId, "Mã phiếu không được để trống.");
            else if (_all.Any(r => !ReferenceEquals(r, editing) && string.Equals(r.Id, id, StringComparison.OrdinalIgnoreCase)))
                SetError(txtId, "Mã phiếu đã tồn tại.");

            if (txtStudentId.Text.Trim().Length == 0)
                SetError(txtStudentId, "Mã sinh viên không được để trống.");

            if (txtStudentName.Text.Trim().Length == 0)
                SetError(txtStudentName, "Họ tên sinh viên không được để trống.");

            if (cboEquipment.SelectedIndex < 0)
                SetError(cboEquipment, "Vui lòng chọn thiết bị.");

            if (nudQuantity.Value <= 0)
                SetError(nudQuantity, "Số lượng phải lớn hơn 0.");

            DateTime borrow = dtpBorrow.Value.Date;
            if (dtpDue.Value.Date < borrow)
                SetError(dtpDue, "Hạn trả không được trước ngày mượn.");

            if (dtpReturn.Checked && dtpReturn.Value.Date < borrow)
                SetError(dtpReturn, "Ngày trả thực tế không được trước ngày mượn.");

            if (_firstInvalid != null)
            {
                _firstInvalid.Focus();
                return false;
            }
            return true;
        }

        // ---------------------------------------------------------------- Xuất CSV (các phiếu đang lọc)
        private void mnuExportCsv_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "phieu_muon_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Mã phiếu,Mã sinh viên,Họ tên sinh viên,Thiết bị,Số lượng,Ngày mượn,Hạn trả,Ngày trả thực tế,Tình trạng");
                foreach (var r in _view)
                {
                    sb.AppendLine(string.Join(",",
                        Csv(r.Id),
                        Csv(r.StudentId),
                        Csv(r.StudentName),
                        Csv(r.Equipment),
                        Csv(r.Quantity.ToString()),
                        Csv(r.BorrowDate.ToString("dd/MM/yyyy")),
                        Csv(r.DueDate.ToString("dd/MM/yyyy")),
                        Csv(r.ReturnDateText),
                        Csv(r.Status)));
                }
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã xuất " + _view.Count + " phiếu ra tệp:\n" + saveFileDialog1.FileName,
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
