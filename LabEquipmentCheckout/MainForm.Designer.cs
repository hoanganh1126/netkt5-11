using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LabEquipmentCheckout
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
            lblTotal = new ToolStripStatusLabel();
            lblOverdue = new ToolStripStatusLabel();
            lblShown = new ToolStripStatusLabel();
            tlpMain = new TableLayoutPanel();
            grpInput = new GroupBox();
            tlpInput = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblStudentName = new Label();
            txtStudentName = new TextBox();
            lblEquipment = new Label();
            cboEquipment = new ComboBox();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            lblBorrow = new Label();
            dtpBorrow = new DateTimePicker();
            lblDue = new Label();
            dtpDue = new DateTimePicker();
            lblReturn = new Label();
            dtpReturn = new DateTimePicker();
            lblStatus = new Label();
            txtStatus = new TextBox();
            flpButtons = new FlowLayoutPanel();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnReturn = new Button();
            btnClear = new Button();
            grpFilter = new GroupBox();
            flpFilter = new FlowLayoutPanel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblFilterStatus = new Label();
            cboFilterStatus = new ComboBox();
            btnClearFilter = new Button();
            dgvRecords = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colStudentId = new DataGridViewTextBoxColumn();
            colStudentName = new DataGridViewTextBoxColumn();
            colEquipment = new DataGridViewTextBoxColumn();
            colQuantity = new DataGridViewTextBoxColumn();
            colBorrow = new DataGridViewTextBoxColumn();
            colDue = new DataGridViewTextBoxColumn();
            colReturn = new DataGridViewTextBoxColumn();
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
            ((ISupportInitialize)nudQuantity).BeginInit();
            ((ISupportInitialize)dgvRecords).BeginInit();
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
            mnuExportCsv.Text = "&Xuất phiếu đang lọc ra CSV...";
            mnuExportCsv.Click += mnuExportCsv_Click;
            mnuExit.Name = "mnuExit";
            mnuExit.Text = "T&hoát";
            mnuExit.Click += mnuExit_Click;

            // statusStrip1
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTotal, lblOverdue, lblShown });
            statusStrip1.Name = "statusStrip1";
            statusStrip1.TabIndex = 2;
            lblTotal.Name = "lblTotal"; lblTotal.Text = "Tổng số phiếu: 0"; lblTotal.BorderSides = ToolStripStatusLabelBorderSides.Right; lblTotal.Margin = new Padding(0, 3, 8, 2); lblTotal.Padding = new Padding(0, 0, 8, 0);
            lblOverdue.Name = "lblOverdue"; lblOverdue.Text = "Quá hạn: 0"; lblOverdue.BorderSides = ToolStripStatusLabelBorderSides.Right; lblOverdue.Margin = new Padding(0, 3, 8, 2); lblOverdue.Padding = new Padding(0, 0, 8, 0);
            lblShown.Name = "lblShown"; lblShown.Text = "Đang hiển thị: 0";

            // tlpMain
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.RowCount = 3;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 262F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(grpInput, 0, 0);
            tlpMain.Controls.Add(grpFilter, 0, 1);
            tlpMain.Controls.Add(dgvRecords, 0, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new Padding(8);
            tlpMain.TabIndex = 1;

            // grpInput
            grpInput.Controls.Add(tlpInput);
            grpInput.Dock = DockStyle.Fill;
            grpInput.Name = "grpInput";
            grpInput.TabStop = false;
            grpInput.Text = "Thông tin phiếu mượn";
            // tlpInput
            tlpInput.ColumnCount = 4;
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpInput.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInput.RowCount = 6;
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tlpInput.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tlpInput.Controls.Add(lblId, 0, 0);
            tlpInput.Controls.Add(txtId, 1, 0);
            tlpInput.Controls.Add(lblStudentId, 2, 0);
            tlpInput.Controls.Add(txtStudentId, 3, 0);
            tlpInput.Controls.Add(lblStudentName, 0, 1);
            tlpInput.Controls.Add(txtStudentName, 1, 1);
            tlpInput.Controls.Add(lblEquipment, 2, 1);
            tlpInput.Controls.Add(cboEquipment, 3, 1);
            tlpInput.Controls.Add(lblQuantity, 0, 2);
            tlpInput.Controls.Add(nudQuantity, 1, 2);
            tlpInput.Controls.Add(lblBorrow, 2, 2);
            tlpInput.Controls.Add(dtpBorrow, 3, 2);
            tlpInput.Controls.Add(lblDue, 0, 3);
            tlpInput.Controls.Add(dtpDue, 1, 3);
            tlpInput.Controls.Add(lblReturn, 2, 3);
            tlpInput.Controls.Add(dtpReturn, 3, 3);
            tlpInput.Controls.Add(lblStatus, 0, 4);
            tlpInput.Controls.Add(txtStatus, 1, 4);
            tlpInput.Controls.Add(flpButtons, 0, 5);
            tlpInput.SetColumnSpan(flpButtons, 4);
            tlpInput.Dock = DockStyle.Fill;
            tlpInput.Name = "tlpInput";
            tlpInput.Padding = new Padding(6, 2, 6, 2);

            // labels
            lblId.AutoSize = true; lblId.Anchor = AnchorStyles.Left; lblId.Name = "lblId"; lblId.Text = "Mã phiếu:";
            lblStudentId.AutoSize = true; lblStudentId.Anchor = AnchorStyles.Left; lblStudentId.Name = "lblStudentId"; lblStudentId.Text = "Mã sinh viên:";
            lblStudentName.AutoSize = true; lblStudentName.Anchor = AnchorStyles.Left; lblStudentName.Name = "lblStudentName"; lblStudentName.Text = "Họ tên sinh viên:";
            lblEquipment.AutoSize = true; lblEquipment.Anchor = AnchorStyles.Left; lblEquipment.Name = "lblEquipment"; lblEquipment.Text = "Thiết bị:";
            lblQuantity.AutoSize = true; lblQuantity.Anchor = AnchorStyles.Left; lblQuantity.Name = "lblQuantity"; lblQuantity.Text = "Số lượng:";
            lblBorrow.AutoSize = true; lblBorrow.Anchor = AnchorStyles.Left; lblBorrow.Name = "lblBorrow"; lblBorrow.Text = "Ngày mượn:";
            lblDue.AutoSize = true; lblDue.Anchor = AnchorStyles.Left; lblDue.Name = "lblDue"; lblDue.Text = "Hạn trả:";
            lblReturn.AutoSize = true; lblReturn.Anchor = AnchorStyles.Left; lblReturn.Name = "lblReturn"; lblReturn.Text = "Ngày trả thực tế:";
            lblStatus.AutoSize = true; lblStatus.Anchor = AnchorStyles.Left; lblStatus.Name = "lblStatus"; lblStatus.Text = "Tình trạng:";

            // input controls
            txtId.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtId.Margin = new Padding(3, 3, 24, 3); txtId.Name = "txtId"; txtId.TabIndex = 0;
            txtStudentId.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtStudentId.Margin = new Padding(3, 3, 24, 3); txtStudentId.Name = "txtStudentId"; txtStudentId.TabIndex = 1;
            txtStudentName.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtStudentName.Margin = new Padding(3, 3, 24, 3); txtStudentName.Name = "txtStudentName"; txtStudentName.TabIndex = 2;

            cboEquipment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboEquipment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEquipment.Margin = new Padding(3, 3, 24, 3);
            cboEquipment.Name = "cboEquipment";
            cboEquipment.TabIndex = 3;

            nudQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nudQuantity.Margin = new Padding(3, 3, 24, 3);
            nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.TabIndex = 4;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });

            dtpBorrow.Anchor = AnchorStyles.Left | AnchorStyles.Right; dtpBorrow.CustomFormat = "dd/MM/yyyy"; dtpBorrow.Format = DateTimePickerFormat.Custom; dtpBorrow.Margin = new Padding(3, 3, 24, 3); dtpBorrow.Name = "dtpBorrow"; dtpBorrow.TabIndex = 5;
            dtpDue.Anchor = AnchorStyles.Left | AnchorStyles.Right; dtpDue.CustomFormat = "dd/MM/yyyy"; dtpDue.Format = DateTimePickerFormat.Custom; dtpDue.Margin = new Padding(3, 3, 24, 3); dtpDue.Name = "dtpDue"; dtpDue.TabIndex = 6;
            dtpDue.ValueChanged += DateFields_Changed;

            dtpReturn.Anchor = AnchorStyles.Left | AnchorStyles.Right; dtpReturn.CustomFormat = "dd/MM/yyyy"; dtpReturn.Format = DateTimePickerFormat.Custom; dtpReturn.Margin = new Padding(3, 3, 24, 3); dtpReturn.Name = "dtpReturn"; dtpReturn.ShowCheckBox = true; dtpReturn.TabIndex = 7;
            dtpReturn.ValueChanged += DateFields_Changed;

            txtStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right; txtStatus.Margin = new Padding(3, 3, 24, 3); txtStatus.Name = "txtStatus"; txtStatus.ReadOnly = true; txtStatus.TabStop = false;

            // flpButtons
            flpButtons.Controls.Add(btnAdd);
            flpButtons.Controls.Add(btnUpdate);
            flpButtons.Controls.Add(btnDelete);
            flpButtons.Controls.Add(btnReturn);
            flpButtons.Controls.Add(btnClear);
            flpButtons.Dock = DockStyle.Fill;
            flpButtons.Name = "flpButtons";
            flpButtons.TabIndex = 8;

            btnAdd.Name = "btnAdd"; btnAdd.Size = new Size(95, 30); btnAdd.TabIndex = 0; btnAdd.Text = "Thêm"; btnAdd.UseVisualStyleBackColor = true; btnAdd.Click += btnAdd_Click;
            btnUpdate.Name = "btnUpdate"; btnUpdate.Size = new Size(95, 30); btnUpdate.TabIndex = 1; btnUpdate.Text = "Cập nhật"; btnUpdate.UseVisualStyleBackColor = true; btnUpdate.Click += btnUpdate_Click;
            btnDelete.Name = "btnDelete"; btnDelete.Size = new Size(95, 30); btnDelete.TabIndex = 2; btnDelete.Text = "Xóa"; btnDelete.UseVisualStyleBackColor = true; btnDelete.Click += btnDelete_Click;
            btnReturn.Name = "btnReturn"; btnReturn.Size = new Size(130, 30); btnReturn.TabIndex = 3; btnReturn.Text = "Đánh dấu đã trả"; btnReturn.UseVisualStyleBackColor = true; btnReturn.Click += btnReturn_Click;
            btnClear.Name = "btnClear"; btnClear.Size = new Size(95, 30); btnClear.TabIndex = 4; btnClear.Text = "Làm mới"; btnClear.UseVisualStyleBackColor = true; btnClear.Click += btnClear_Click;

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

            lblSearch.AutoSize = true; lblSearch.Margin = new Padding(6, 7, 3, 0); lblSearch.Name = "lblSearch"; lblSearch.Text = "Mã SV / Tên thiết bị:";
            txtSearch.Margin = new Padding(3, 4, 16, 3); txtSearch.Name = "txtSearch"; txtSearch.Size = new Size(220, 23); txtSearch.TabIndex = 9;
            txtSearch.TextChanged += Filter_Changed;
            lblFilterStatus.AutoSize = true; lblFilterStatus.Margin = new Padding(3, 7, 3, 0); lblFilterStatus.Name = "lblFilterStatus"; lblFilterStatus.Text = "Hiển thị phiếu:";
            cboFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList; cboFilterStatus.Margin = new Padding(3, 4, 16, 3); cboFilterStatus.Name = "cboFilterStatus"; cboFilterStatus.Size = new Size(140, 23); cboFilterStatus.TabIndex = 10;
            cboFilterStatus.SelectedIndexChanged += Filter_Changed;
            btnClearFilter.Margin = new Padding(3, 2, 3, 3); btnClearFilter.Name = "btnClearFilter"; btnClearFilter.Size = new Size(100, 27); btnClearFilter.TabIndex = 11; btnClearFilter.Text = "Bỏ lọc"; btnClearFilter.UseVisualStyleBackColor = true;
            btnClearFilter.Click += btnClearFilter_Click;

            // dgvRecords
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;
            dgvRecords.AllowUserToResizeRows = false;
            dgvRecords.AutoGenerateColumns = false;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.BackgroundColor = SystemColors.Window;
            dgvRecords.Columns.AddRange(new DataGridViewColumn[] { colId, colStudentId, colStudentName, colEquipment, colQuantity, colBorrow, colDue, colReturn, colStatus });
            dgvRecords.Dock = DockStyle.Fill;
            dgvRecords.MultiSelect = false;
            dgvRecords.Name = "dgvRecords";
            dgvRecords.ReadOnly = true;
            dgvRecords.RowHeadersVisible = false;
            dgvRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecords.TabIndex = 12;
            dgvRecords.CellFormatting += dgvRecords_CellFormatting;
            dgvRecords.SelectionChanged += dgvRecords_SelectionChanged;

            colId.DataPropertyName = "Id"; colId.FillWeight = 65F; colId.HeaderText = "Mã phiếu"; colId.Name = "colId"; colId.SortMode = DataGridViewColumnSortMode.NotSortable;
            colStudentId.DataPropertyName = "StudentId"; colStudentId.FillWeight = 80F; colStudentId.HeaderText = "Mã sinh viên"; colStudentId.Name = "colStudentId"; colStudentId.SortMode = DataGridViewColumnSortMode.NotSortable;
            colStudentName.DataPropertyName = "StudentName"; colStudentName.FillWeight = 120F; colStudentName.HeaderText = "Họ tên sinh viên"; colStudentName.Name = "colStudentName"; colStudentName.SortMode = DataGridViewColumnSortMode.NotSortable;
            colEquipment.DataPropertyName = "Equipment"; colEquipment.FillWeight = 120F; colEquipment.HeaderText = "Thiết bị"; colEquipment.Name = "colEquipment"; colEquipment.SortMode = DataGridViewColumnSortMode.NotSortable;
            colQuantity.DataPropertyName = "Quantity"; colQuantity.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; colQuantity.FillWeight = 55F; colQuantity.HeaderText = "Số lượng"; colQuantity.Name = "colQuantity"; colQuantity.SortMode = DataGridViewColumnSortMode.NotSortable;
            colBorrow.DataPropertyName = "BorrowDate"; colBorrow.DefaultCellStyle.Format = "dd/MM/yyyy"; colBorrow.FillWeight = 80F; colBorrow.HeaderText = "Ngày mượn"; colBorrow.Name = "colBorrow"; colBorrow.SortMode = DataGridViewColumnSortMode.NotSortable;
            colDue.DataPropertyName = "DueDate"; colDue.DefaultCellStyle.Format = "dd/MM/yyyy"; colDue.FillWeight = 80F; colDue.HeaderText = "Hạn trả"; colDue.Name = "colDue"; colDue.SortMode = DataGridViewColumnSortMode.NotSortable;
            colReturn.DataPropertyName = "ReturnDateText"; colReturn.FillWeight = 90F; colReturn.HeaderText = "Ngày trả thực tế"; colReturn.Name = "colReturn"; colReturn.SortMode = DataGridViewColumnSortMode.NotSortable;
            colStatus.DataPropertyName = "Status"; colStatus.FillWeight = 75F; colStatus.HeaderText = "Tình trạng"; colStatus.Name = "colStatus"; colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

            // errorProvider1
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;

            // saveFileDialog1
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.Filter = "Tệp CSV (*.csv)|*.csv";
            saveFileDialog1.Title = "Xuất phiếu mượn";

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 680);
            Controls.Add(tlpMain);
            Controls.Add(menuStrip1);
            Controls.Add(statusStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(950, 640);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab Equipment Checkout - Quản lý mượn trả thiết bị";

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
            ((ISupportInitialize)nudQuantity).EndInit();
            ((ISupportInitialize)dgvRecords).EndInit();
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
        private ToolStripStatusLabel lblTotal;
        private ToolStripStatusLabel lblOverdue;
        private ToolStripStatusLabel lblShown;
        private TableLayoutPanel tlpMain;
        private GroupBox grpInput;
        private TableLayoutPanel tlpInput;
        private Label lblId;
        private TextBox txtId;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblStudentName;
        private TextBox txtStudentName;
        private Label lblEquipment;
        private ComboBox cboEquipment;
        private Label lblQuantity;
        private NumericUpDown nudQuantity;
        private Label lblBorrow;
        private DateTimePicker dtpBorrow;
        private Label lblDue;
        private DateTimePicker dtpDue;
        private Label lblReturn;
        private DateTimePicker dtpReturn;
        private Label lblStatus;
        private TextBox txtStatus;
        private FlowLayoutPanel flpButtons;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnReturn;
        private Button btnClear;
        private GroupBox grpFilter;
        private FlowLayoutPanel flpFilter;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblFilterStatus;
        private ComboBox cboFilterStatus;
        private Button btnClearFilter;
        private DataGridView dgvRecords;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colStudentId;
        private DataGridViewTextBoxColumn colStudentName;
        private DataGridViewTextBoxColumn colEquipment;
        private DataGridViewTextBoxColumn colQuantity;
        private DataGridViewTextBoxColumn colBorrow;
        private DataGridViewTextBoxColumn colDue;
        private DataGridViewTextBoxColumn colReturn;
        private DataGridViewTextBoxColumn colStatus;
        private BindingSource bindingSource1;
        private ErrorProvider errorProvider1;
        private SaveFileDialog saveFileDialog1;
    }
}
