using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RepairServiceTracker
{
    public partial class MainForm : Form
    {
        private const string StatusDone = "Hoàn tất";

        private static readonly string[] DeviceTypes = { "Điện thoại", "Laptop", "Máy tính bảng", "Tivi", "Máy in", "Khác" };
        private static readonly string[] Statuses = { "Mới tiếp nhận", "Đang sửa", "Chờ linh kiện", "Hoàn tất", "Đã hủy" };

        private readonly BindingList<RepairOrder> _all = new BindingList<RepairOrder>();   // toàn bộ đơn
        private readonly BindingList<RepairOrder> _view = new BindingList<RepairOrder>();  // đơn sau khi lọc (gắn vào lưới)

        private RepairOrder _selected;
        private string _imagePath;       // đường dẫn ảnh đang hiển thị trên form
        private bool _suppress;
        private Control _firstInvalid;

        public MainForm()
        {
            InitializeComponent();

            cboDeviceType.Items.AddRange(DeviceTypes);
            cboStatus.Items.AddRange(Statuses);
            cboFilterStatus.Items.Add("Tất cả");
            cboFilterStatus.Items.AddRange(Statuses);
            cboFilterStatus.SelectedIndex = 0;

            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSource1.DataSource = _view;
            dgvOrders.DataSource = bindingSource1;

            SeedData();
            ApplyFilter();
            ClearForm();
        }

        // ---------------------------------------------------------------- Dữ liệu mẫu
        private void SeedData()
        {
            DateTime d = DateTime.Today;
            _all.Add(new RepairOrder { Id = "SC001", CustomerName = "Nguyễn Văn An", Phone = "0912345678", DeviceType = "Điện thoại", Description = "Vỡ màn hình, cần thay màn mới", ReceivedDate = d.AddDays(-3), EstimatedCost = 1500000m, Status = "Đang sửa" });
            _all.Add(new RepairOrder { Id = "SC002", CustomerName = "Trần Thị Bình", Phone = "0987654321", DeviceType = "Laptop", Description = "Máy không lên nguồn", ReceivedDate = d.AddDays(-5), EstimatedCost = 800000m, Status = "Chờ linh kiện" });
            _all.Add(new RepairOrder { Id = "SC003", CustomerName = "Lê Minh Châu", Phone = "0903111222", DeviceType = "Tivi", Description = "Mất hình, còn tiếng", ReceivedDate = d.AddDays(-10), EstimatedCost = 2200000m, Status = "Hoàn tất" });
            _all.Add(new RepairOrder { Id = "SC004", CustomerName = "Phạm Quốc Dũng", Phone = "0977888999", DeviceType = "Máy in", Description = "Kẹt giấy liên tục", ReceivedDate = d.AddDays(-1), EstimatedCost = 350000m, Status = "Mới tiếp nhận" });
            _all.Add(new RepairOrder { Id = "SC005", CustomerName = "Hoàng Thu Hà", Phone = "0935123456", DeviceType = "Máy tính bảng", Description = "Pin chai, sạc không vào", ReceivedDate = d, EstimatedCost = 450000m, Status = "Đã hủy" });
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
            string kwPhone = NormalizePhone(kw);
            string status = cboFilterStatus.SelectedIndex > 0 ? (string)cboFilterStatus.SelectedItem : null;

            var result = _all.Where(o =>
                    (kw.Length == 0
                        || o.Id.Contains(kw, StringComparison.CurrentCultureIgnoreCase)
                        || o.CustomerName.Contains(kw, StringComparison.CurrentCultureIgnoreCase)
                        || (kwPhone.Length > 0 && NormalizePhone(o.Phone).Contains(kwPhone)))
                    && (status == null || o.Status == status))
                .ToList();

            RepairOrder prev = _selected;
            _suppress = true;
            try
            {
                _view.RaiseListChangedEvents = false;
                _view.Clear();
                foreach (var o in result) _view.Add(o);
                _view.RaiseListChangedEvents = true;
                _view.ResetBindings();

                dgvOrders.ClearSelection();
                _selected = null;
                if (prev != null)
                {
                    int idx = _view.IndexOf(prev);
                    if (idx >= 0)
                    {
                        dgvOrders.Rows[idx].Selected = true;
                        dgvOrders.CurrentCell = dgvOrders.Rows[idx].Cells[0];
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
            lblCount.Text = "Số đơn theo bộ lọc: " + _view.Count + " / " + _all.Count;
            decimal total = _all.Where(o => o.Status != StatusDone).Sum(o => o.EstimatedCost);
            lblTotalCost.Text = "Tổng chi phí dự kiến (đơn chưa hoàn tất): " + total.ToString("N0") + " đ";
        }

        // ---------------------------------------------------------------- Chọn dòng -> nạp lên form
        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (_suppress || dgvOrders.SelectedRows.Count == 0) return;
            var o = dgvOrders.SelectedRows[0].DataBoundItem as RepairOrder;
            if (o == null) return;

            _selected = o;
            errorProvider1.Clear();
            txtId.Text = o.Id;
            txtCustomer.Text = o.CustomerName;
            txtPhone.Text = o.Phone;
            cboDeviceType.SelectedItem = o.DeviceType;
            dtpReceived.Value = o.ReceivedDate;
            txtCost.Text = o.EstimatedCost.ToString("N0");
            cboStatus.SelectedItem = o.Status;
            txtDescription.Text = o.Description;
            _imagePath = o.ImagePath;
            ShowImage(_imagePath);
        }

        // ---------------------------------------------------------------- Ảnh thiết bị
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                LoadImageIntoBox(openFileDialog1.FileName);
                _imagePath = openFileDialog1.FileName;
            }
            catch (Exception)
            {
                MessageBox.Show("Tệp được chọn không phải ảnh hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _imagePath = null;
            ShowImage(null);
        }

        private void ShowImage(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    LoadImageIntoBox(path);
                else
                    SetPictureImage(null);
            }
            catch (Exception)
            {
                SetPictureImage(null);
            }
        }

        // Đọc ảnh vào bộ nhớ (không khóa tệp trên đĩa)
        private void LoadImageIntoBox(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var img = Image.FromStream(fs))
            {
                SetPictureImage(new Bitmap(img));
            }
        }

        private void SetPictureImage(Image img)
        {
            Image old = pbDevice.Image;
            pbDevice.Image = img;   // SizeMode = Zoom nên ảnh giữ đúng tỷ lệ
            if (old != null) old.Dispose();
        }

        // ---------------------------------------------------------------- Thêm / Cập nhật / Xóa
        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal cost;
            if (!ValidateInput(null, out cost)) return;

            if (MessageBox.Show("Bạn có chắc muốn thêm đơn sửa chữa này?", "Xác nhận thêm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var o = new RepairOrder();
            ReadForm(o, cost);
            _all.Add(o);
            _selected = null;
            ApplyFilter();
            ClearForm();
            MessageBox.Show("Đã thêm đơn sửa chữa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn trên bảng để cập nhật.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal cost;
            if (!ValidateInput(_selected, out cost)) return;

            if (MessageBox.Show("Bạn có chắc muốn cập nhật đơn \"" + _selected.Id + "\"?", "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            ReadForm(_selected, cost);
            ApplyFilter();   // làm mới bảng, số đơn và tổng chi phí trên StatusStrip
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Vui lòng chọn một đơn trên bảng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa đơn \"" + _selected.Id + "\" của " + _selected.CustomerName + "?",
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
            dgvOrders.ClearSelection();
            txtId.Text = NextId();
            txtCustomer.Text = "";
            txtPhone.Text = "";
            cboDeviceType.SelectedIndex = 0;
            dtpReceived.Value = DateTime.Today;
            txtCost.Text = "0";
            cboStatus.SelectedIndex = 0;
            txtDescription.Text = "";
            _imagePath = null;
            ShowImage(null);
            txtCustomer.Focus();
        }

        private string NextId()
        {
            int n = _all.Count + 1;
            string id;
            do { id = "SC" + n.ToString("D3"); n++; } while (_all.Any(o => o.Id == id));
            return id;
        }

        private void ReadForm(RepairOrder o, decimal cost)
        {
            o.Id = txtId.Text.Trim();
            o.CustomerName = txtCustomer.Text.Trim();
            o.Phone = txtPhone.Text.Trim();
            o.DeviceType = (string)cboDeviceType.SelectedItem;
            o.Description = txtDescription.Text.Trim();
            o.ReceivedDate = dtpReceived.Value.Date;
            o.EstimatedCost = cost;
            o.Status = (string)cboStatus.SelectedItem;
            o.ImagePath = _imagePath;
        }

        // ---------------------------------------------------------------- Kiểm tra dữ liệu (ErrorProvider)
        private void SetError(Control c, string message)
        {
            errorProvider1.SetError(c, message);
            if (_firstInvalid == null) _firstInvalid = c;
        }

        private bool ValidateInput(RepairOrder editing, out decimal cost)
        {
            errorProvider1.Clear();
            _firstInvalid = null;

            string id = txtId.Text.Trim();
            if (id.Length == 0)
                SetError(txtId, "Mã đơn không được để trống.");
            else if (_all.Any(o => !ReferenceEquals(o, editing) && string.Equals(o.Id, id, StringComparison.OrdinalIgnoreCase)))
                SetError(txtId, "Mã đơn đã tồn tại.");

            if (txtCustomer.Text.Trim().Length == 0)
                SetError(txtCustomer, "Tên khách hàng không được để trống.");

            if (txtPhone.Text.Trim().Length == 0)
                SetError(txtPhone, "Số điện thoại không được để trống.");

            if (cboDeviceType.SelectedIndex < 0)
                SetError(cboDeviceType, "Vui lòng chọn loại thiết bị.");

            if (cboStatus.SelectedIndex < 0)
                SetError(cboStatus, "Vui lòng chọn trạng thái.");

            if (txtDescription.Text.Trim().Length == 0)
                SetError(txtDescription, "Mô tả lỗi là bắt buộc.");

            if (!TryParseCost(txtCost.Text, out cost))
                SetError(txtCost, "Chi phí dự kiến phải là một số hợp lệ.");
            else if (cost < 0)
                SetError(txtCost, "Chi phí dự kiến không được âm.");

            if (_firstInvalid != null)
            {
                _firstInvalid.Focus();
                return false;
            }
            return true;
        }

        private static bool TryParseCost(string text, out decimal value)
        {
            text = (text ?? "").Trim();
            if (text.Length == 0) { value = 0; return false; }
            return decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value)
                || decimal.TryParse(text, NumberStyles.Number, CultureInfo.InvariantCulture, out value);
        }

        private static string NormalizePhone(string s)
        {
            return Regex.Replace(s ?? "", @"[\s.\-()]", "");
        }

        // ---------------------------------------------------------------- Xuất CSV
        private void mnuExportCsv_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "don_sua_chua_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".csv";
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;

            try
            {
                var sb = new StringBuilder();
                sb.AppendLine("Mã đơn,Tên khách hàng,Số điện thoại,Loại thiết bị,Mô tả lỗi,Ngày tiếp nhận,Chi phí dự kiến,Trạng thái");
                foreach (var o in _view)
                {
                    sb.AppendLine(string.Join(",",
                        Csv(o.Id),
                        Csv(o.CustomerName),
                        Csv("=\"" + o.Phone + "\""),   // giữ số 0 đầu khi mở bằng Excel
                        Csv(o.DeviceType),
                        Csv(o.Description),
                        Csv(o.ReceivedDate.ToString("dd/MM/yyyy")),
                        Csv(o.EstimatedCost.ToString("0.##", CultureInfo.InvariantCulture)),
                        Csv(o.Status)));
                }
                File.WriteAllText(saveFileDialog1.FileName, sb.ToString(), new UTF8Encoding(true));
                MessageBox.Show("Đã xuất " + _view.Count + " đơn ra tệp:\n" + saveFileDialog1.FileName,
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
