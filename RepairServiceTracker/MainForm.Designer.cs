using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RepairServiceTracker
{
    partial class MainForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new Container();
            menuStrip1 = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuExportCsv = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblCount = new ToolStripStatusLabel();
            lblTotalCost = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            grpInput = new GroupBox();
            tlpInput = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblCustomer = new Label();
            txtCustomer = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblDeviceType = new Label();
            cboDeviceType = new ComboBox();
            lblReceived = new Label();
            dtpReceived = new DateTimePicker();
            lblCost = new Label();
            txtCost = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            grpImage = new GroupBox();
            pbDevice = new PictureBox();
            pnlImageButtons = new Panel();
            btnChooseImage = new Button();
            btnClearImage = new Button();
            grpFilter = new GroupBox();
            flpFilter = new FlowLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblFilterStatus = new Label();
            cboFilterStatus = new ComboBox();
            btnClearFilter = new Button();
            dgvOrders = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colCustomer = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colDeviceType = new DataGridViewTextBoxColumn();
            colDescription = new DataGridViewTextBoxColumn();
            colReceived = new DataGridViewTextBoxColumn();
            colCost = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tlpMain.SuspendLayout();
            grpInput.SuspendLayout();
            tlpInput.SuspendLayout();
            flpButtons.SuspendLayout();
            grpImage.SuspendLayout();
            ((ISupportInitialize)pbDevice).BeginInit();
            pnlImageButtons.SuspendLayout();
            grpFilter.SuspendLayout();
            flpFilter.SuspendLayout();
            ((ISupportInitialize)dgvOrders).BeginInit();
            ((ISupportInitialize)bindingSource1).BeginInit();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile });
            menuStrip1.Name = "menuStrip1";
            menuStrip1.TabIndex = 0;
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuExportCsv, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Text = "&Tệp";
            mnuExportCsv.Name = "mnuExportCsv";
            mnuExportCsv.ShortcutKeys = Keys.Control | Keys.E;
            mnuExportCsv.Text = "&Xuất danh sách ra CSV...";
            mnuExportCsv.Click += mnuExportCsv_Click;
            mnuExit.Name = "mnuExit";
            mnuExit.ShortcutKeys = Keys.Alt | Keys.F4;
            mnuExit.Text = "T&hoát";
            mnuExit.Click += mnuExit_Click;

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblCount, lblTotalCost });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.TabIndex = 2;
            lblCount.Name = "lblCount"; lblCount.Text = "Số đơn: 0"; lblCount.BorderSides = ToolStripStatusLabelBorderSides.Right; lblCount.Margin = new Padding(0, 3, 8, 2); lblCount.Padding = new Padding(0, 0, 8, 0);
            lblTotalCost.Name = "lblTotalCost"; lblTotalCost.Text = "Tổng chi phí dự kiến (đơn chưa hoàn tất): 0 đ";

            // tlpMain : 2 cột (nhập liệu | ảnh), 3 hàng (nhập liệu | lọc | lưới)
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(grpInput, 0, 0);
            tlpMain.Controls.Add(grpImage, 1, 0);
            tlpMain.Controls.Add(grpFilter, 0, 1);
            tlpMain.Controls.Add(dgvOrders, 0, 2);
            tlpMain.SetColumnSpan(grpFilter, 2);
            tlpMain.SetColumnSpan(dgvOrders, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(8);
            tlpMain.TabIndex = 1;

            // grpInput
            grpInput.Controls.Add(tlpInput);
            grpInput.Dock = DockStyle.Fill;
            grpInput.Name = "grpInput";
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin đơn";
            // tlpInput
            tlpInput.ColumnCount = 4;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 115F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.RowCount = 6;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tlpInput.Controls.Add(lblId, 0, 0);
            tlpInput.Controls.Add(txtId, 1, 0);
            tlpInput.Controls.Add(lblCustomer, 2, 0);
            tlpInput.Controls.Add(txtCustomer, 3, 0);
            tlpInput.Controls.Add(lblPhone, 0, 1);
            tlpInput.Controls.Add(txtPhone, 1, 1);
            tlpInput.Controls.Add(lblDeviceType, 2, 1);
            tlpInput.Controls.Add(cboDeviceType, 3, 1);
            tlpInput.Controls.Add(lblReceived, 0, 2);
            tlpInput.Controls.Add(dtpReceived, 1, 2);
            tlpInput.Controls.Add(lblCost, 2, 2);
            tlpInput.Controls.Add(txtCost, 3, 2);
            tlpInput.Controls.Add(lblStatus, 0, 3);
            tlpInput.Controls.Add(cboStatus, 1, 3);
            tlpInput.Controls.Add(lblDescription, 0, 4);
            tlpInput.Controls.Add(txtDescription, 1, 4);
            tlpInput.Controls.Add(flpButtons, 0, 5);
            tlpInput.SetColumnSpan(txtDescription, 3);
            tlpInput.SetColumnSpan(flpButtons, 4);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(6, 2, 6, 2);

            // labels
            lblId.AutoSize = true; lblId.Anchor = AnchorStyles.Left; lblId.Name = "lblId"; lblId.Text = "Mã đơn:";
            lblCustomer.AutoSize = true; lblCustomer.Anchor = AnchorStyles.Left; lblCustomer.Name = "lblCustomer"; lblCustomer.Text = "Tên khách hàng:";
            lblPhone.AutoSize = true; lblPhone.Anchor = AnchorStyles.Left; lblPhone.Name = "lblPhone"; lblPhone.Text = "Số điện thoại:";
            lblDeviceType.AutoSize = true; lblDeviceType.Anchor = AnchorStyles.Left; lblDeviceType.Name = "lblDeviceType"; lblDeviceType.Text = "Loại thiết bị:";
            lblReceived.AutoSize = true; lblReceived.Anchor = AnchorStyles.Left; lblReceived.Name = "lblReceived"; lblReceived.Text = "Ngày tiếp nhận:";
            lblCost.AutoSize = true; lblCost.Anchor = AnchorStyles.Left; lblCost.Name = "lblCost"; lblCost.Text = "Chi phí dự kiến:";
            lblStatus.AutoSize = true; lblStatus.Anchor = AnchorStyles.Left; lblStatus.Name = "lblStatus"; lblStatus.Text = "Trạng thái:";
            lblDescription.AutoSize = true; lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left; lblDescription.Margin = new Padding(3, 9, 3, 0); lblDescription.Name = "lblDescription"; lblDescription.Text = "Mô tả lỗi:";

            // input controls
            txtId.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtId.Margin = new Padding(3, 3, 24, 3); txtId.Name = "txtId"; txtId.TabIndex = 0;
            txtCustomer.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtCustomer.Margin = new Padding(3, 3, 24, 3); txtCustomer.Name = "txtCustomer"; txtCustomer.TabIndex = 1;
            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtPhone.Margin = new Padding(3, 3, 24, 3); txtPhone.Name = "txtPhone"; txtPhone.TabIndex = 2;

            cboDeviceType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboDeviceType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDeviceType.Margin = new Padding(3, 3, 24, 3);
            cboDeviceType.Name = "cboDeviceType";
            cboDeviceType.TabIndex = 3;

            dtpReceived.Anchor = AnchorStyles.Left | AnchorStyles.Right; dtpReceived.CustomFormat = "dd/MM/yyyy"; dtpReceived.Format = DateTimePickerFormat.Custom; dtpReceived.Margin = new Padding(3, 3, 24, 3); dtpReceived.Name = "dtpReceived"; dtpReceived.TabIndex = 4;

            txtCost.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtCost.Margin = new Padding(3, 3, 24, 3); txtCost.Name = "txtCost"; txtCost.TabIndex = 5; txtCost.TextAlign = HorizontalAlignment.Right;

            cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Margin = new Padding(3, 3, 24, 3);
            cboStatus.Name = "cboStatus";
            cboStatus.TabIndex = 6;

            txtDescription.Dock = DockStyle.Fill;
            txtDescription.Margin = new Padding(3, 3, 24, 3);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.TabIndex = 7;

            // flpButtons
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnClear);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Name = "flpButtons";
            flpButtons.TabIndex = 8;

            btnAdd.Name = "btnAdd"; btnAdd.Size = new Size(95, 30); btnAdd.TabIndex = 0; btnAdd.Text = "Thêm"; btnAdd.UseVisualStyleBackColor = true; btnAdd.Click += btnAdd_Click;
            btnUpdate.Name = "btnUpdate"; btnUpdate.Size = new Size(95, 30); btnUpdate.TabIndex = 1; btnUpdate.Text = "Cập nhật"; btnUpdate.UseVisualStyleBackColor = true; btnUpdate.Click += btnUpdate_Click;
            btnDelete.Name = "btnDelete"; btnDelete.Size = new Size(95, 30); btnDelete.TabIndex = 2; btnDelete.Text = "Xóa"; btnDelete.UseVisualStyleBackColor = true; btnDelete.Click += btnDelete_Click;
            btnClear.Name = "btnClear"; btnClear.Size = new Size(95, 30); btnClear.TabIndex = 3; btnClear.Text = "Làm mới"; btnClear.UseVisualStyleBackColor = true; btnClear.Click += btnClear_Click;

            // grpImage : PictureBox + nút chọn ảnh
            grpImage.Controls.Add(pbDevice);
            grpImage.Controls.Add(pnlImageButtons);
            grpImage.Dock = DockStyle.Fill;
            grpImage.Name = "grpImage";
            grpImage.TabStop = false;
            grpImage.Text = "Ảnh thiết bị";

            pbDevice.BackColor = SystemColors.ControlLight;
            pbDevice.BorderStyle = BorderStyle.FixedSingle;
            pbDevice.Dock = DockStyle.Fill;
            pbDevice.Name = "pbDevice";
            pbDevice.SizeMode = PictureBoxSizeMode.Zoom;   // hiển thị đúng tỷ lệ, không méo
            pbDevice.TabStop = false;

            pnlImageButtons.Controls.Add(btnChooseImage);
            pnlImageButtons.Controls.Add(btnClearImage);
            pnlImageButtons.Dock = DockStyle.Bottom;
            pnlImageButtons.Name = "pnlImageButtons";
            pnlImageButtons.Size = new Size(234, 40);

            btnChooseImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnChooseImage.Location = new Point(4, 6);
            btnChooseImage.Name = "btnChooseImage";
            btnChooseImage.Size = new Size(110, 30);
            btnChooseImage.TabIndex = 9;
            btnChooseImage.Text = "Chọn ảnh...";
            btnChooseImage.UseVisualStyleBackColor = true;
            btnChooseImage.Click += btnChooseImage_Click;

            btnClearImage.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearImage.Location = new Point(120, 6);
            btnClearImage.Name = "btnClearImage";
            btnClearImage.Size = new Size(106, 30);
            btnClearImage.TabIndex = 10;
            btnClearImage.Text = "Bỏ ảnh";
            btnClearImage.UseVisualStyleBackColor = true;
            btnClearImage.Click += btnClearImage_Click;

            // grpFilter
            grpFilter.Controls.Add(flpFilter);
            grpFilter.Dock = DockStyle.Fill;
            grpFilter.Name = "grpFilter";
            grpFilter.TabStop = false;
            grpFilter.Text = "Tìm kiếm và lọc";
            flpFilter.Controls.Add(lblSearch);
            flpFilter.Controls.Add(txtSearch);
            flpFilter.Controls.Add(lblFilterStatus);
            flpFilter.Controls.Add(cboFilterStatus);
            flpFilter.Controls.Add(btnClearFilter);
            flpFilter.Dock = DockStyle.Fill;
            flpFilter.Name = "flpFilter";
            flpFilter.WrapContents = false;

            lblSearch.AutoSize = true; lblSearch.Margin = new Padding(6, 7, 3, 0); lblSearch.Name = "lblSearch"; lblSearch.Text = "Mã đơn / Tên / SĐT:";
            txtSearch.Margin = new Padding(3, 4, 16, 3); txtSearch.Name = "txtSearch"; txtSearch.Size = new Size(220, 23); txtSearch.TabIndex = 11;
            txtSearch.TextChanged += Filter_Changed;
            lblFilterStatus.AutoSize = true; lblFilterStatus.Margin = new Padding(3, 7, 3, 0); lblFilterStatus.Name = "lblFilterStatus"; lblFilterStatus.Text = "Trạng thái:";
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList; cboFilterStatus.Margin = new Padding(3, 4, 16, 3); cboFilterStatus.Name = "cboFilterStatus"; cboFilterStatus.Size = new Size(140, 23); cboFilterStatus.TabIndex = 12;
            cboFilterStatus.SelectedIndexChanged += Filter_Changed;
            btnClearFilter.Margin = new Padding(3, 2, 3, 3); btnClearFilter.Name = "btnClearFilter"; btnClearFilter.Size = new Size(100, 27); btnClearFilter.TabIndex = 13; btnClearFilter.Text = "Bỏ lọc"; btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Click += btnClearFilter_Click;

            // dgvOrders
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AllowUserToResizeRows = false;
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = SystemColors.Window;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colId, colCustomer, colPhone, colDeviceType, colDescription, colReceived, colCost, colStatus });
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.TabIndex = 14;
            dgvOrders.SelectionChanged += dgvOrders_SelectionChanged;

            colId.DataPropertyName = "Id"; colId.FillWeight = 60F; colId.HeaderText = "Mã đơn"; colId.Name = "colId"; colId.SortMode = DataGridViewColumnSortMode.NotSortable;
            colCustomer.DataPropertyName = "CustomerName"; colCustomer.FillWeight = 110F; colCustomer.HeaderText = "Khách hàng"; colCustomer.Name = "colCustomer"; colCustomer.SortMode = DataGridViewColumnSortMode.NotSortable;
            colPhone.DataPropertyName = "Phone"; colPhone.FillWeight = 85F; colPhone.HeaderText = "Số điện thoại"; colPhone.Name = "colPhone"; colPhone.SortMode = DataGridViewColumnSortMode.NotSortable;
            colDeviceType.DataPropertyName = "DeviceType"; colDeviceType.FillWeight = 85F; colDeviceType.HeaderText = "Loại thiết bị"; colDeviceType.Name = "colDeviceType"; colDeviceType.SortMode = DataGridViewColumnSortMode.NotSortable;
            colDescription.DataPropertyName = "Description"; colDescription.FillWeight = 160F; colDescription.HeaderText = "Mô tả lỗi"; colDescription.Name = "colDescription"; colDescription.SortMode = DataGridViewColumnSortMode.NotSortable;
            colReceived.DataPropertyName = "ReceivedDate"; colReceived.DefaultCellStyle.Format = "dd/MM/yyyy"; colReceived.FillWeight = 80F; colReceived.HeaderText = "Ngày tiếp nhận"; colReceived.Name = "colReceived"; colReceived.SortMode = DataGridViewColumnSortMode.NotSortable;
            colCost.DataPropertyName = "EstimatedCost"; colCost.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; colCost.DefaultCellStyle.Format = "N0"; colCost.FillWeight = 90F; colCost.HeaderText = "Chi phí dự kiến"; colCost.Name = "colCost"; colCost.SortMode = DataGridViewColumnSortMode.NotSortable;
            colStatus.DataPropertyName = "Status"; colStatus.FillWeight = 85F; colStatus.HeaderText = "Trạng thái"; colStatus.Name = "colStatus"; colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

            // errorProvider1
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            // saveFileDialog1
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "Tệp CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Xuất danh sách đơn sửa chữa";

            // openFileDialog1
            openFileDialog1.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả tệp (*.*)|*.*";
            openFileDialog1.Title = "Chọn ảnh thiết bị";

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 720);
            Controls.Add(tlpMain);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(960, 680);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Repair Service Tracker - Quản lý đơn đăng ký dịch vụ sửa chữa";

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tlpMain.ResumeLayout(false);
            grpInput.ResumeLayout(false);
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            flpButtons.ResumeLayout(false);
            grpImage.ResumeLayout(false);
            ((ISupportInitialize)pbDevice).EndInit();
            pnlImageButtons.ResumeLayout(false);
            grpFilter.ResumeLayout(false);
            flpFilter.ResumeLayout(false);
            flpFilter.PerformLayout();
            ((ISupportInitialize)dgvOrders).EndInit();
            ((ISupportInitialize)bindingSource1).EndInit();
            ((ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuFile;
        private ToolStripMenuItem mnuExportCsv;
        private ToolStripMenuItem mnuExit;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblCount;
        private ToolStripStatusLabel lblTotalCost;
        private TableLayoutPanel tlpMain;
        private GroupBox grpInput;
        private TableLayoutPanel tlpInput;
        private Label lblId;
        private TextBox txtId;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblDeviceType;
        private ComboBox cboDeviceType;
        private Label lblReceived;
        private DateTimePicker dtpReceived;
        private Label lblCost;
        private TextBox txtCost;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblDescription;
        private TextBox txtDescription;
        private FlowLayoutPanel flpButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpImage;
        private PictureBox pbDevice;
        private Panel pnlImageButtons;
        private Button btnChooseImage;
        private Button btnClearImage;
        private GroupBox grpFilter;
        private FlowLayoutPanel flpFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private Button btnClearFilter;
        private DataGridView dgvOrders;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colCustomer;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colDeviceType;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colReceived;
        private DataGridViewTextBoxColumn colCost;
        private DataGridViewTextBoxColumn colStatus;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}
