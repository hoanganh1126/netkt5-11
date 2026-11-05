using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicAppointmentManager
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
            lblStatusCount = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            grpInput = new GroupBox();
            tlpInput = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblDate = new Label();
            dtpAppointment = new DateTimePicker();
            lblName = new Label();
            txtName = new TextBox();
            lblDoctor = new Label();
            cboDoctor = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblReason = new Label();
            txtReason = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnClear = new Button();
            grpFilter = new GroupBox();
            flpFilter = new FlowLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            chkFilterDate = new CheckBox();
            dtpFilterDate = new DateTimePicker();
            lblFilterStatus = new Label();
            cboFilterStatus = new ComboBox();
            btnClearFilter = new Button();
            dgvAppointments = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPhone = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colReason = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            errorProvider1 = new ErrorProvider(components);
            saveFileDialog1 = new SaveFileDialog();

            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tlpMain.SuspendLayout();
            grpInput.SuspendLayout();
            tlpInput.SuspendLayout();
            flpButtons.SuspendLayout();
            grpFilter.SuspendLayout();
            flpFilter.SuspendLayout();
            ((ISupportInitialize)dgvAppointments).BeginInit();
            ((ISupportInitialize)bindingSource1).BeginInit();
            ((ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 24);
            menuStrip1.TabIndex = 0;
            // mnuFile
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuExportCsv, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Text = "&Tệp";
            // mnuExportCsv
            mnuExportCsv.Name = "mnuExportCsv";
            mnuExportCsv.ShortcutKeys = Keys.Control | Keys.E;
            mnuExportCsv.Text = "&Xuất danh sách ra CSV...";
            mnuExportCsv.Click += mnuExportCsv_Click;
            // mnuExit
            mnuExit.Name = "mnuExit";
            mnuExit.Text = "T&hoát";
            mnuExit.Click += mnuExit_Click;

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatusCount });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.TabIndex = 2;
            // lblStatusCount
            lblStatusCount.Name = "lblStatusCount";
            lblStatusCount.Text = "Số lịch hẹn: 0";

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 225F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(grpInput, 0, 0);
            tlpMain.Controls.Add(grpFilter, 0, 1);
            tlpMain.Controls.Add(dgvAppointments, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(8);
            tlpMain.TabIndex = 1;

            // grpInput
            grpInput.Controls.Add(tlpInput);
            grpInput.Dock = DockStyle.Fill;
            grpInput.Name = "grpInput";
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin lịch hẹn";
            // tlpInput
            tlpInput.ColumnCount = 4;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.RowCount = 5;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tlpInput.Controls.Add(lblId, 0, 0);
            tlpInput.Controls.Add(txtId, 1, 0);
            tlpInput.Controls.Add(lblDate, 2, 0);
            tlpInput.Controls.Add(dtpAppointment, 3, 0);
            tlpInput.Controls.Add(lblName, 0, 1);
            tlpInput.Controls.Add(txtName, 1, 1);
            tlpInput.Controls.Add(lblDoctor, 2, 1);
            tlpInput.Controls.Add(cboDoctor, 3, 1);
            tlpInput.Controls.Add(lblPhone, 0, 2);
            tlpInput.Controls.Add(txtPhone, 1, 2);
            tlpInput.Controls.Add(lblStatus, 2, 2);
            tlpInput.Controls.Add(cboStatus, 3, 2);
            tlpInput.Controls.Add(lblReason, 0, 3);
            tlpInput.Controls.Add(txtReason, 1, 3);
            tlpInput.Controls.Add(flpButtons, 0, 4);
            tlpInput.SetColumnSpan(txtReason, 3);
            tlpInput.SetColumnSpan(flpButtons, 4);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(6, 2, 6, 2);

            // labels
            lblId.AutoSize = true; lblId.Anchor = AnchorStyles.Left; lblId.Name = "lblId"; lblId.Text = "Mã lịch hẹn:";
            lblDate.AutoSize = true; lblDate.Anchor = AnchorStyles.Left; lblDate.Name = "lblDate"; lblDate.Text = "Ngày giờ hẹn:";
            lblName.AutoSize = true; lblName.Anchor = AnchorStyles.Left; lblName.Name = "lblName"; lblName.Text = "Họ tên bệnh nhân:";
            lblDoctor.AutoSize = true; lblDoctor.Anchor = AnchorStyles.Left; lblDoctor.Name = "lblDoctor"; lblDoctor.Text = "Bác sĩ:";
            lblPhone.AutoSize = true; lblPhone.Anchor = AnchorStyles.Left; lblPhone.Name = "lblPhone"; lblPhone.Text = "Số điện thoại:";
            lblStatus.AutoSize = true; lblStatus.Anchor = AnchorStyles.Left; lblStatus.Name = "lblStatus"; lblStatus.Text = "Trạng thái:";
            lblReason.AutoSize = true; lblReason.Anchor = AnchorStyles.Left; lblReason.Name = "lblReason"; lblReason.Text = "Lý do khám:";

            // input controls
            txtId.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtId.Margin = new Padding(3, 3, 24, 3);
            txtId.Name = "txtId";
            txtId.TabIndex = 0;

            dtpAppointment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpAppointment.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpAppointment.Format = DateTimePickerFormat.Custom;
            dtpAppointment.Margin = new Padding(3, 3, 24, 3);
            dtpAppointment.Name = "dtpAppointment";
            dtpAppointment.TabIndex = 1;

            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Margin = new Padding(3, 3, 24, 3);
            txtName.Name = "txtName";
            txtName.TabIndex = 2;

            cboDoctor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboDoctor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoctor.Margin = new Padding(3, 3, 24, 3);
            cboDoctor.Name = "cboDoctor";
            cboDoctor.TabIndex = 3;

            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Margin = new Padding(3, 3, 24, 3);
            txtPhone.Name = "txtPhone";
            txtPhone.TabIndex = 4;

            cboStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Margin = new Padding(3, 3, 24, 3);
            cboStatus.Name = "cboStatus";
            cboStatus.TabIndex = 5;

            txtReason.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtReason.Margin = new Padding(3, 3, 24, 3);
            txtReason.Name = "txtReason";
            txtReason.TabIndex = 6;

            // flpButtons
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnClear);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Name = "flpButtons";
            flpButtons.TabIndex = 7;

            btnAdd.Name = "btnAdd"; btnAdd.Size = new Size(95, 30); btnAdd.TabIndex = 0; btnAdd.Text = "Thêm"; btnAdd.UseVisualStyleBackColor = true; btnAdd.Click += btnAdd_Click;
            btnUpdate.Name = "btnUpdate"; btnUpdate.Size = new Size(95, 30); btnUpdate.TabIndex = 1; btnUpdate.Text = "Cập nhật"; btnUpdate.UseVisualStyleBackColor = true; btnUpdate.Click += btnUpdate_Click;
            btnDelete.Name = "btnDelete"; btnDelete.Size = new Size(95, 30); btnDelete.TabIndex = 2; btnDelete.Text = "Xóa"; btnDelete.UseVisualStyleBackColor = true; btnDelete.Click += btnDelete_Click;
            btnClear.Name = "btnClear"; btnClear.Size = new Size(95, 30); btnClear.TabIndex = 3; btnClear.Text = "Làm mới"; btnClear.UseVisualStyleBackColor = true; btnClear.Click += btnClear_Click;

            // grpFilter
            grpFilter.Controls.Add(flpFilter);
            grpFilter.Dock = DockStyle.Fill;
            grpFilter.Name = "grpFilter";
            grpFilter.TabStop = false;
            grpFilter.Text = "Tìm kiếm và lọc";
            // flpFilter
            flpFilter.Controls.Add(lblSearch);
            flpFilter.Controls.Add(txtSearch);
            flpFilter.Controls.Add(chkFilterDate);
            flpFilter.Controls.Add(dtpFilterDate);
            flpFilter.Controls.Add(lblFilterStatus);
            flpFilter.Controls.Add(cboFilterStatus);
            flpFilter.Controls.Add(btnClearFilter);
            flpFilter.Dock = DockStyle.Fill;
            flpFilter.Name = "flpFilter";
            flpFilter.WrapContents = false;

            lblSearch.AutoSize = true; lblSearch.Margin = new Padding(6, 7, 3, 0); lblSearch.Name = "lblSearch"; lblSearch.Text = "Tên / SĐT:";
            txtSearch.Margin = new Padding(3, 4, 12, 3); txtSearch.Name = "txtSearch"; txtSearch.Size = new Size(200, 23); txtSearch.TabIndex = 8;
            txtSearch.TextChanged += Filter_Changed;
            chkFilterDate.AutoSize = true; chkFilterDate.Margin = new Padding(3, 6, 3, 0); chkFilterDate.Name = "chkFilterDate"; chkFilterDate.TabIndex = 9; chkFilterDate.Text = "Lọc theo ngày:"; chkFilterDate.UseVisualStyleBackColor = true;
            chkFilterDate.CheckedChanged += Filter_Changed;
            dtpFilterDate.Format = DateTimePickerFormat.Custom; dtpFilterDate.CustomFormat = "dd/MM/yyyy"; dtpFilterDate.Margin = new Padding(3, 4, 12, 3); dtpFilterDate.Name = "dtpFilterDate"; dtpFilterDate.Size = new Size(110, 23); dtpFilterDate.TabIndex = 10;
            dtpFilterDate.ValueChanged += Filter_Changed;
            lblFilterStatus.AutoSize = true; lblFilterStatus.Margin = new Padding(3, 7, 3, 0); lblFilterStatus.Name = "lblFilterStatus"; lblFilterStatus.Text = "Trạng thái:";
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList; cboFilterStatus.Margin = new Padding(3, 4, 12, 3); cboFilterStatus.Name = "cboFilterStatus"; cboFilterStatus.Size = new Size(130, 23); cboFilterStatus.TabIndex = 11;
            cboFilterStatus.SelectedIndexChanged += Filter_Changed;
            btnClearFilter.Margin = new Padding(3, 2, 3, 3); btnClearFilter.Name = "btnClearFilter"; btnClearFilter.Size = new Size(100, 27); btnClearFilter.TabIndex = 12; btnClearFilter.Text = "Bỏ lọc"; btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Click += btnClearFilter_Click;

            // dgvAppointments
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.AllowUserToResizeRows = false;
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = SystemColors.Window;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPhone, colTime, colDoctor, colReason, colStatus });
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.MultiSelect = false;
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.TabIndex = 13;
            dgvAppointments.SelectionChanged += dgvAppointments_SelectionChanged;

            colId.DataPropertyName = "Id"; colId.FillWeight = 70F; colId.HeaderText = "Mã lịch hẹn"; colId.Name = "colId"; colId.SortMode = DataGridViewColumnSortMode.NotSortable;
            colName.DataPropertyName = "PatientName"; colName.FillWeight = 130F; colName.HeaderText = "Họ tên bệnh nhân"; colName.Name = "colName"; colName.SortMode = DataGridViewColumnSortMode.NotSortable;
            colPhone.DataPropertyName = "Phone"; colPhone.FillWeight = 85F; colPhone.HeaderText = "Số điện thoại"; colPhone.Name = "colPhone"; colPhone.SortMode = DataGridViewColumnSortMode.NotSortable;
            colTime.DataPropertyName = "AppointmentTime"; colTime.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm"; colTime.FillWeight = 100F; colTime.HeaderText = "Ngày giờ hẹn"; colTime.Name = "colTime"; colTime.SortMode = DataGridViewColumnSortMode.NotSortable;
            colDoctor.DataPropertyName = "Doctor"; colDoctor.FillWeight = 120F; colDoctor.HeaderText = "Bác sĩ"; colDoctor.Name = "colDoctor"; colDoctor.SortMode = DataGridViewColumnSortMode.NotSortable;
            colReason.DataPropertyName = "Reason"; colReason.FillWeight = 160F; colReason.HeaderText = "Lý do khám"; colReason.Name = "colReason"; colReason.SortMode = DataGridViewColumnSortMode.NotSortable;
            colStatus.DataPropertyName = "Status"; colStatus.FillWeight = 80F; colStatus.HeaderText = "Trạng thái"; colStatus.Name = "colStatus"; colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

            // errorProvider1
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            // saveFileDialog1
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "Tệp CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Xuất danh sách lịch hẹn";

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 640);
            Controls.Add(tlpMain);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 600);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clinic Appointment Manager - Quản lý lịch hẹn phòng khám";

            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tlpMain.ResumeLayout(false);
            grpInput.ResumeLayout(false);
            tlpInput.ResumeLayout(false);
            tlpInput.PerformLayout();
            flpButtons.ResumeLayout(false);
            grpFilter.ResumeLayout(false);
            flpFilter.ResumeLayout(false);
            flpFilter.PerformLayout();
            ((ISupportInitialize)dgvAppointments).EndInit();
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
        private ToolStripStatusLabel lblStatusCount;
        private TableLayoutPanel tlpMain;
        private GroupBox grpInput;
        private TableLayoutPanel tlpInput;
        private Label lblId;
        private TextBox txtId;
        private Label lblDate;
        private DateTimePicker dtpAppointment;
        private Label lblName;
        private TextBox txtName;
        private Label lblDoctor;
        private ComboBox cboDoctor;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblReason;
        private TextBox txtReason;
        private FlowLayoutPanel flpButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private GroupBox grpFilter;
        private FlowLayoutPanel flpFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private CheckBox chkFilterDate;
        private DateTimePicker dtpFilterDate;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private Button btnClearFilter;
        private DataGridView dgvAppointments;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPhone;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colReason;
        private DataGridViewTextBoxColumn colStatus;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
        private SaveFileDialog saveFileDialog1;
    }
}
