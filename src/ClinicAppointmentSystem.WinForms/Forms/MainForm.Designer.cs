namespace ClinicAppointmentSystem.WinForms.Forms;

partial class MainForm
{
    /// <summary>Required designer variable.</summary>
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.tabMain = new System.Windows.Forms.TabControl();
        this.tabPatients = new System.Windows.Forms.TabPage();
        this.tabDoctors = new System.Windows.Forms.TabPage();
        this.tabAppointments = new System.Windows.Forms.TabPage();
        this.tabDepartments = new System.Windows.Forms.TabPage();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

        // --- Patients tab controls ---
        this.dgvPatients = new System.Windows.Forms.DataGridView();
        this.pnlPatientButtons = new System.Windows.Forms.Panel();
        this.btnAddPatient = new System.Windows.Forms.Button();
        this.btnViewRecord = new System.Windows.Forms.Button();
        this.btnDeletePatient = new System.Windows.Forms.Button();
        this.lblPatientSearch = new System.Windows.Forms.Label();
        this.txtPatientSearch = new System.Windows.Forms.TextBox();

        // --- Doctors tab controls ---
        this.dgvDoctors = new System.Windows.Forms.DataGridView();
        this.pnlDoctorButtons = new System.Windows.Forms.Panel();
        this.btnAddDoctor = new System.Windows.Forms.Button();
        this.btnViewSchedule = new System.Windows.Forms.Button();
        this.lblFilterSpec = new System.Windows.Forms.Label();
        this.cmbFilterSpecialization = new System.Windows.Forms.ComboBox();

        // --- Appointments tab controls ---
        this.dgvAppointments = new System.Windows.Forms.DataGridView();
        this.pnlAppointmentButtons = new System.Windows.Forms.Panel();
        this.btnBookAppointment = new System.Windows.Forms.Button();
        this.btnCompleteAppointment = new System.Windows.Forms.Button();
        this.btnCancelAppointment = new System.Windows.Forms.Button();
        this.btnNoShow = new System.Windows.Forms.Button();
        this.grpFilterStatus = new System.Windows.Forms.GroupBox();
        this.radAll = new System.Windows.Forms.RadioButton();
        this.radScheduled = new System.Windows.Forms.RadioButton();
        this.radCompleted = new System.Windows.Forms.RadioButton();
        this.radCancelled = new System.Windows.Forms.RadioButton();

        // --- Departments tab controls ---
        this.dgvDepartments = new System.Windows.Forms.DataGridView();
        this.lstDepartmentDoctors = new System.Windows.Forms.ListBox();
        this.lblDeptDoctors = new System.Windows.Forms.Label();
        this.pnlDepartmentButtons = new System.Windows.Forms.Panel();
        this.btnAddDepartment = new System.Windows.Forms.Button();
        this.btnRemoveDepartment = new System.Windows.Forms.Button();
        this.splitDepartments = new System.Windows.Forms.SplitContainer();

        this.tabMain.SuspendLayout();
        this.tabPatients.SuspendLayout();
        this.tabDoctors.SuspendLayout();
        this.tabAppointments.SuspendLayout();
        this.tabDepartments.SuspendLayout();
        this.statusStrip.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.splitDepartments)).BeginInit();
        this.splitDepartments.Panel1.SuspendLayout();
        this.splitDepartments.Panel2.SuspendLayout();
        this.splitDepartments.SuspendLayout();
        this.pnlPatientButtons.SuspendLayout();
        this.pnlDoctorButtons.SuspendLayout();
        this.pnlAppointmentButtons.SuspendLayout();
        this.pnlDepartmentButtons.SuspendLayout();
        this.grpFilterStatus.SuspendLayout();
        this.SuspendLayout();

        // ============================= tabMain =============================
        this.tabMain.Controls.Add(this.tabPatients);
        this.tabMain.Controls.Add(this.tabDoctors);
        this.tabMain.Controls.Add(this.tabAppointments);
        this.tabMain.Controls.Add(this.tabDepartments);
        this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabMain.Location = new System.Drawing.Point(0, 0);
        this.tabMain.Name = "tabMain";
        this.tabMain.SelectedIndex = 0;
        this.tabMain.Size = new System.Drawing.Size(1000, 618);
        this.tabMain.TabIndex = 0;
        this.tabMain.Padding = new System.Drawing.Point(14, 6);

        // ============================ tabPatients ==========================
        this.tabPatients.Controls.Add(this.dgvPatients);
        this.tabPatients.Controls.Add(this.pnlPatientButtons);
        this.tabPatients.Location = new System.Drawing.Point(4, 29);
        this.tabPatients.Name = "tabPatients";
        this.tabPatients.Padding = new System.Windows.Forms.Padding(10);
        this.tabPatients.Size = new System.Drawing.Size(992, 585);
        this.tabPatients.TabIndex = 0;
        this.tabPatients.Text = "Patients";
        this.tabPatients.UseVisualStyleBackColor = true;

        this.dgvPatients.AllowUserToAddRows = false;
        this.dgvPatients.AllowUserToDeleteRows = false;
        this.dgvPatients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvPatients.Location = new System.Drawing.Point(10, 10);
        this.dgvPatients.MultiSelect = false;
        this.dgvPatients.Name = "dgvPatients";
        this.dgvPatients.ReadOnly = true;
        this.dgvPatients.RowHeadersVisible = false;
        this.dgvPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvPatients.Size = new System.Drawing.Size(972, 505);
        this.dgvPatients.TabIndex = 0;
        this.dgvPatients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellDoubleClick);

        this.pnlPatientButtons.Controls.Add(this.txtPatientSearch);
        this.pnlPatientButtons.Controls.Add(this.lblPatientSearch);
        this.pnlPatientButtons.Controls.Add(this.btnDeletePatient);
        this.pnlPatientButtons.Controls.Add(this.btnViewRecord);
        this.pnlPatientButtons.Controls.Add(this.btnAddPatient);
        this.pnlPatientButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlPatientButtons.Location = new System.Drawing.Point(10, 515);
        this.pnlPatientButtons.Name = "pnlPatientButtons";
        this.pnlPatientButtons.Size = new System.Drawing.Size(972, 60);
        this.pnlPatientButtons.TabIndex = 1;

        this.btnAddPatient.Location = new System.Drawing.Point(3, 14);
        this.btnAddPatient.Name = "btnAddPatient";
        this.btnAddPatient.Size = new System.Drawing.Size(150, 34);
        this.btnAddPatient.TabIndex = 0;
        this.btnAddPatient.Text = "Register Patient";
        this.btnAddPatient.UseVisualStyleBackColor = true;
        this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);

        this.btnViewRecord.Location = new System.Drawing.Point(159, 14);
        this.btnViewRecord.Name = "btnViewRecord";
        this.btnViewRecord.Size = new System.Drawing.Size(170, 34);
        this.btnViewRecord.TabIndex = 1;
        this.btnViewRecord.Text = "View Medical Record";
        this.btnViewRecord.UseVisualStyleBackColor = true;
        this.btnViewRecord.Click += new System.EventHandler(this.btnViewRecord_Click);

        this.btnDeletePatient.Location = new System.Drawing.Point(335, 14);
        this.btnDeletePatient.Name = "btnDeletePatient";
        this.btnDeletePatient.Size = new System.Drawing.Size(150, 34);
        this.btnDeletePatient.TabIndex = 2;
        this.btnDeletePatient.Text = "Delete Patient";
        this.btnDeletePatient.UseVisualStyleBackColor = true;
        this.btnDeletePatient.Click += new System.EventHandler(this.btnDeletePatient_Click);

        this.lblPatientSearch.AutoSize = true;
        this.lblPatientSearch.Location = new System.Drawing.Point(600, 24);
        this.lblPatientSearch.Name = "lblPatientSearch";
        this.lblPatientSearch.Size = new System.Drawing.Size(51, 20);
        this.lblPatientSearch.TabIndex = 3;
        this.lblPatientSearch.Text = "Search:";

        this.txtPatientSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.txtPatientSearch.Location = new System.Drawing.Point(657, 20);
        this.txtPatientSearch.Name = "txtPatientSearch";
        this.txtPatientSearch.PlaceholderText = "name or contact number";
        this.txtPatientSearch.Size = new System.Drawing.Size(312, 27);
        this.txtPatientSearch.TabIndex = 4;
        this.txtPatientSearch.TextChanged += new System.EventHandler(this.txtPatientSearch_TextChanged);

        // ============================= tabDoctors ==========================
        this.tabDoctors.Controls.Add(this.dgvDoctors);
        this.tabDoctors.Controls.Add(this.pnlDoctorButtons);
        this.tabDoctors.Location = new System.Drawing.Point(4, 29);
        this.tabDoctors.Name = "tabDoctors";
        this.tabDoctors.Padding = new System.Windows.Forms.Padding(10);
        this.tabDoctors.Size = new System.Drawing.Size(992, 585);
        this.tabDoctors.TabIndex = 1;
        this.tabDoctors.Text = "Doctors";
        this.tabDoctors.UseVisualStyleBackColor = true;

        this.dgvDoctors.AllowUserToAddRows = false;
        this.dgvDoctors.AllowUserToDeleteRows = false;
        this.dgvDoctors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvDoctors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvDoctors.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvDoctors.Location = new System.Drawing.Point(10, 10);
        this.dgvDoctors.MultiSelect = false;
        this.dgvDoctors.Name = "dgvDoctors";
        this.dgvDoctors.ReadOnly = true;
        this.dgvDoctors.RowHeadersVisible = false;
        this.dgvDoctors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvDoctors.Size = new System.Drawing.Size(972, 505);
        this.dgvDoctors.TabIndex = 0;

        this.pnlDoctorButtons.Controls.Add(this.cmbFilterSpecialization);
        this.pnlDoctorButtons.Controls.Add(this.lblFilterSpec);
        this.pnlDoctorButtons.Controls.Add(this.btnViewSchedule);
        this.pnlDoctorButtons.Controls.Add(this.btnAddDoctor);
        this.pnlDoctorButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlDoctorButtons.Location = new System.Drawing.Point(10, 515);
        this.pnlDoctorButtons.Name = "pnlDoctorButtons";
        this.pnlDoctorButtons.Size = new System.Drawing.Size(972, 60);
        this.pnlDoctorButtons.TabIndex = 1;

        this.btnAddDoctor.Location = new System.Drawing.Point(3, 14);
        this.btnAddDoctor.Name = "btnAddDoctor";
        this.btnAddDoctor.Size = new System.Drawing.Size(150, 34);
        this.btnAddDoctor.TabIndex = 0;
        this.btnAddDoctor.Text = "Add Doctor";
        this.btnAddDoctor.UseVisualStyleBackColor = true;
        this.btnAddDoctor.Click += new System.EventHandler(this.btnAddDoctor_Click);

        this.btnViewSchedule.Location = new System.Drawing.Point(159, 14);
        this.btnViewSchedule.Name = "btnViewSchedule";
        this.btnViewSchedule.Size = new System.Drawing.Size(150, 34);
        this.btnViewSchedule.TabIndex = 1;
        this.btnViewSchedule.Text = "View Schedule";
        this.btnViewSchedule.UseVisualStyleBackColor = true;
        this.btnViewSchedule.Click += new System.EventHandler(this.btnViewSchedule_Click);

        this.lblFilterSpec.AutoSize = true;
        this.lblFilterSpec.Location = new System.Drawing.Point(560, 24);
        this.lblFilterSpec.Name = "lblFilterSpec";
        this.lblFilterSpec.Size = new System.Drawing.Size(105, 20);
        this.lblFilterSpec.TabIndex = 2;
        this.lblFilterSpec.Text = "Specialization:";

        this.cmbFilterSpecialization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.cmbFilterSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbFilterSpecialization.Location = new System.Drawing.Point(671, 20);
        this.cmbFilterSpecialization.Name = "cmbFilterSpecialization";
        this.cmbFilterSpecialization.Size = new System.Drawing.Size(298, 28);
        this.cmbFilterSpecialization.TabIndex = 3;
        this.cmbFilterSpecialization.SelectedIndexChanged += new System.EventHandler(this.cmbFilterSpecialization_SelectedIndexChanged);

        // ========================== tabAppointments ========================
        this.tabAppointments.Controls.Add(this.dgvAppointments);
        this.tabAppointments.Controls.Add(this.pnlAppointmentButtons);
        this.tabAppointments.Location = new System.Drawing.Point(4, 29);
        this.tabAppointments.Name = "tabAppointments";
        this.tabAppointments.Padding = new System.Windows.Forms.Padding(10);
        this.tabAppointments.Size = new System.Drawing.Size(992, 585);
        this.tabAppointments.TabIndex = 2;
        this.tabAppointments.Text = "Appointments";
        this.tabAppointments.UseVisualStyleBackColor = true;

        this.dgvAppointments.AllowUserToAddRows = false;
        this.dgvAppointments.AllowUserToDeleteRows = false;
        this.dgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvAppointments.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvAppointments.Location = new System.Drawing.Point(10, 10);
        this.dgvAppointments.MultiSelect = false;
        this.dgvAppointments.Name = "dgvAppointments";
        this.dgvAppointments.ReadOnly = true;
        this.dgvAppointments.RowHeadersVisible = false;
        this.dgvAppointments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvAppointments.Size = new System.Drawing.Size(972, 475);
        this.dgvAppointments.TabIndex = 0;

        this.pnlAppointmentButtons.Controls.Add(this.grpFilterStatus);
        this.pnlAppointmentButtons.Controls.Add(this.btnNoShow);
        this.pnlAppointmentButtons.Controls.Add(this.btnCancelAppointment);
        this.pnlAppointmentButtons.Controls.Add(this.btnCompleteAppointment);
        this.pnlAppointmentButtons.Controls.Add(this.btnBookAppointment);
        this.pnlAppointmentButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlAppointmentButtons.Location = new System.Drawing.Point(10, 485);
        this.pnlAppointmentButtons.Name = "pnlAppointmentButtons";
        this.pnlAppointmentButtons.Size = new System.Drawing.Size(972, 90);
        this.pnlAppointmentButtons.TabIndex = 1;

        this.btnBookAppointment.Location = new System.Drawing.Point(3, 28);
        this.btnBookAppointment.Name = "btnBookAppointment";
        this.btnBookAppointment.Size = new System.Drawing.Size(160, 34);
        this.btnBookAppointment.TabIndex = 0;
        this.btnBookAppointment.Text = "Book Appointment";
        this.btnBookAppointment.UseVisualStyleBackColor = true;
        this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);

        this.btnCompleteAppointment.Location = new System.Drawing.Point(169, 28);
        this.btnCompleteAppointment.Name = "btnCompleteAppointment";
        this.btnCompleteAppointment.Size = new System.Drawing.Size(150, 34);
        this.btnCompleteAppointment.TabIndex = 1;
        this.btnCompleteAppointment.Text = "Mark Completed";
        this.btnCompleteAppointment.UseVisualStyleBackColor = true;
        this.btnCompleteAppointment.Click += new System.EventHandler(this.btnCompleteAppointment_Click);

        this.btnCancelAppointment.Location = new System.Drawing.Point(325, 28);
        this.btnCancelAppointment.Name = "btnCancelAppointment";
        this.btnCancelAppointment.Size = new System.Drawing.Size(150, 34);
        this.btnCancelAppointment.TabIndex = 2;
        this.btnCancelAppointment.Text = "Cancel";
        this.btnCancelAppointment.UseVisualStyleBackColor = true;
        this.btnCancelAppointment.Click += new System.EventHandler(this.btnCancelAppointment_Click);

        this.btnNoShow.Location = new System.Drawing.Point(481, 28);
        this.btnNoShow.Name = "btnNoShow";
        this.btnNoShow.Size = new System.Drawing.Size(150, 34);
        this.btnNoShow.TabIndex = 3;
        this.btnNoShow.Text = "Mark No-Show";
        this.btnNoShow.UseVisualStyleBackColor = true;
        this.btnNoShow.Click += new System.EventHandler(this.btnNoShow_Click);

        // GroupBox scopes these RadioButtons into ONE mutually exclusive group.
        this.grpFilterStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.grpFilterStatus.Controls.Add(this.radCancelled);
        this.grpFilterStatus.Controls.Add(this.radCompleted);
        this.grpFilterStatus.Controls.Add(this.radScheduled);
        this.grpFilterStatus.Controls.Add(this.radAll);
        this.grpFilterStatus.Location = new System.Drawing.Point(660, 5);
        this.grpFilterStatus.Name = "grpFilterStatus";
        this.grpFilterStatus.Size = new System.Drawing.Size(309, 80);
        this.grpFilterStatus.TabIndex = 4;
        this.grpFilterStatus.TabStop = false;
        this.grpFilterStatus.Text = "Filter by status";

        this.radAll.AutoSize = true;
        this.radAll.Checked = true;
        this.radAll.Location = new System.Drawing.Point(12, 26);
        this.radAll.Name = "radAll";
        this.radAll.Size = new System.Drawing.Size(48, 24);
        this.radAll.TabIndex = 0;
        this.radAll.TabStop = true;
        this.radAll.Text = "All";
        this.radAll.UseVisualStyleBackColor = true;
        this.radAll.CheckedChanged += new System.EventHandler(this.StatusFilter_CheckedChanged);

        this.radScheduled.AutoSize = true;
        this.radScheduled.Location = new System.Drawing.Point(66, 26);
        this.radScheduled.Name = "radScheduled";
        this.radScheduled.Size = new System.Drawing.Size(100, 24);
        this.radScheduled.TabIndex = 1;
        this.radScheduled.Text = "Scheduled";
        this.radScheduled.UseVisualStyleBackColor = true;
        this.radScheduled.CheckedChanged += new System.EventHandler(this.StatusFilter_CheckedChanged);

        this.radCompleted.AutoSize = true;
        this.radCompleted.Location = new System.Drawing.Point(172, 26);
        this.radCompleted.Name = "radCompleted";
        this.radCompleted.Size = new System.Drawing.Size(103, 24);
        this.radCompleted.TabIndex = 2;
        this.radCompleted.Text = "Completed";
        this.radCompleted.UseVisualStyleBackColor = true;
        this.radCompleted.CheckedChanged += new System.EventHandler(this.StatusFilter_CheckedChanged);

        this.radCancelled.AutoSize = true;
        this.radCancelled.Location = new System.Drawing.Point(12, 51);
        this.radCancelled.Name = "radCancelled";
        this.radCancelled.Size = new System.Drawing.Size(95, 24);
        this.radCancelled.TabIndex = 3;
        this.radCancelled.Text = "Cancelled";
        this.radCancelled.UseVisualStyleBackColor = true;
        this.radCancelled.CheckedChanged += new System.EventHandler(this.StatusFilter_CheckedChanged);

        // =========================== tabDepartments ========================
        this.tabDepartments.Controls.Add(this.splitDepartments);
        this.tabDepartments.Controls.Add(this.pnlDepartmentButtons);
        this.tabDepartments.Location = new System.Drawing.Point(4, 29);
        this.tabDepartments.Name = "tabDepartments";
        this.tabDepartments.Padding = new System.Windows.Forms.Padding(10);
        this.tabDepartments.Size = new System.Drawing.Size(992, 585);
        this.tabDepartments.TabIndex = 3;
        this.tabDepartments.Text = "Departments";
        this.tabDepartments.UseVisualStyleBackColor = true;

        this.splitDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitDepartments.Location = new System.Drawing.Point(10, 10);
        this.splitDepartments.Name = "splitDepartments";
        this.splitDepartments.Panel1.Controls.Add(this.dgvDepartments);
        this.splitDepartments.Panel2.Controls.Add(this.lstDepartmentDoctors);
        this.splitDepartments.Panel2.Controls.Add(this.lblDeptDoctors);
        this.splitDepartments.Size = new System.Drawing.Size(972, 505);
        this.splitDepartments.SplitterDistance = 560;
        this.splitDepartments.TabIndex = 0;

        this.dgvDepartments.AllowUserToAddRows = false;
        this.dgvDepartments.AllowUserToDeleteRows = false;
        this.dgvDepartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvDepartments.Location = new System.Drawing.Point(0, 0);
        this.dgvDepartments.MultiSelect = false;
        this.dgvDepartments.Name = "dgvDepartments";
        this.dgvDepartments.ReadOnly = true;
        this.dgvDepartments.RowHeadersVisible = false;
        this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        this.dgvDepartments.Size = new System.Drawing.Size(560, 505);
        this.dgvDepartments.TabIndex = 0;
        this.dgvDepartments.SelectionChanged += new System.EventHandler(this.dgvDepartments_SelectionChanged);

        this.lblDeptDoctors.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblDeptDoctors.Location = new System.Drawing.Point(0, 0);
        this.lblDeptDoctors.Name = "lblDeptDoctors";
        this.lblDeptDoctors.Padding = new System.Windows.Forms.Padding(8, 6, 0, 6);
        this.lblDeptDoctors.Size = new System.Drawing.Size(408, 32);
        this.lblDeptDoctors.TabIndex = 0;
        this.lblDeptDoctors.Text = "Doctors in department";

        this.lstDepartmentDoctors.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lstDepartmentDoctors.FormattingEnabled = true;
        this.lstDepartmentDoctors.ItemHeight = 20;
        this.lstDepartmentDoctors.Location = new System.Drawing.Point(0, 32);
        this.lstDepartmentDoctors.Name = "lstDepartmentDoctors";
        this.lstDepartmentDoctors.Size = new System.Drawing.Size(408, 473);
        this.lstDepartmentDoctors.TabIndex = 1;

        this.pnlDepartmentButtons.Controls.Add(this.btnRemoveDepartment);
        this.pnlDepartmentButtons.Controls.Add(this.btnAddDepartment);
        this.pnlDepartmentButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlDepartmentButtons.Location = new System.Drawing.Point(10, 515);
        this.pnlDepartmentButtons.Name = "pnlDepartmentButtons";
        this.pnlDepartmentButtons.Size = new System.Drawing.Size(972, 60);
        this.pnlDepartmentButtons.TabIndex = 1;

        this.btnAddDepartment.Location = new System.Drawing.Point(3, 14);
        this.btnAddDepartment.Name = "btnAddDepartment";
        this.btnAddDepartment.Size = new System.Drawing.Size(150, 34);
        this.btnAddDepartment.TabIndex = 0;
        this.btnAddDepartment.Text = "Add Department";
        this.btnAddDepartment.UseVisualStyleBackColor = true;
        this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);

        this.btnRemoveDepartment.Location = new System.Drawing.Point(159, 14);
        this.btnRemoveDepartment.Name = "btnRemoveDepartment";
        this.btnRemoveDepartment.Size = new System.Drawing.Size(230, 34);
        this.btnRemoveDepartment.TabIndex = 1;
        this.btnRemoveDepartment.Text = "Remove Department (Rule 11 demo)";
        this.btnRemoveDepartment.UseVisualStyleBackColor = true;
        this.btnRemoveDepartment.Click += new System.EventHandler(this.btnRemoveDepartment_Click);

        // ============================ statusStrip ==========================
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
        this.statusStrip.Location = new System.Drawing.Point(0, 618);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1000, 26);
        this.statusStrip.TabIndex = 1;

        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(151, 20);
        this.lblStatus.Text = "Ready";

        // =============================== MainForm ==========================
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 644);
        this.Controls.Add(this.tabMain);
        this.Controls.Add(this.statusStrip);
        this.MinimumSize = new System.Drawing.Size(900, 600);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Clinic Appointment System — Tagum City Community Clinic";
        this.Load += new System.EventHandler(this.MainForm_Load);

        this.grpFilterStatus.ResumeLayout(false);
        this.grpFilterStatus.PerformLayout();
        this.pnlDepartmentButtons.ResumeLayout(false);
        this.pnlAppointmentButtons.ResumeLayout(false);
        this.pnlDoctorButtons.ResumeLayout(false);
        this.pnlDoctorButtons.PerformLayout();
        this.pnlPatientButtons.ResumeLayout(false);
        this.pnlPatientButtons.PerformLayout();
        this.splitDepartments.Panel1.ResumeLayout(false);
        this.splitDepartments.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitDepartments)).EndInit();
        this.splitDepartments.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDoctors)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.tabDepartments.ResumeLayout(false);
        this.tabAppointments.ResumeLayout(false);
        this.tabDoctors.ResumeLayout(false);
        this.tabPatients.ResumeLayout(false);
        this.tabMain.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TabControl tabMain;
    private System.Windows.Forms.TabPage tabPatients;
    private System.Windows.Forms.TabPage tabDoctors;
    private System.Windows.Forms.TabPage tabAppointments;
    private System.Windows.Forms.TabPage tabDepartments;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;

    private System.Windows.Forms.DataGridView dgvPatients;
    private System.Windows.Forms.Panel pnlPatientButtons;
    private System.Windows.Forms.Button btnAddPatient;
    private System.Windows.Forms.Button btnViewRecord;
    private System.Windows.Forms.Button btnDeletePatient;
    private System.Windows.Forms.Label lblPatientSearch;
    private System.Windows.Forms.TextBox txtPatientSearch;

    private System.Windows.Forms.DataGridView dgvDoctors;
    private System.Windows.Forms.Panel pnlDoctorButtons;
    private System.Windows.Forms.Button btnAddDoctor;
    private System.Windows.Forms.Button btnViewSchedule;
    private System.Windows.Forms.Label lblFilterSpec;
    private System.Windows.Forms.ComboBox cmbFilterSpecialization;

    private System.Windows.Forms.DataGridView dgvAppointments;
    private System.Windows.Forms.Panel pnlAppointmentButtons;
    private System.Windows.Forms.Button btnBookAppointment;
    private System.Windows.Forms.Button btnCompleteAppointment;
    private System.Windows.Forms.Button btnCancelAppointment;
    private System.Windows.Forms.Button btnNoShow;
    private System.Windows.Forms.GroupBox grpFilterStatus;
    private System.Windows.Forms.RadioButton radAll;
    private System.Windows.Forms.RadioButton radScheduled;
    private System.Windows.Forms.RadioButton radCompleted;
    private System.Windows.Forms.RadioButton radCancelled;

    private System.Windows.Forms.DataGridView dgvDepartments;
    private System.Windows.Forms.ListBox lstDepartmentDoctors;
    private System.Windows.Forms.Label lblDeptDoctors;
    private System.Windows.Forms.Panel pnlDepartmentButtons;
    private System.Windows.Forms.Button btnAddDepartment;
    private System.Windows.Forms.Button btnRemoveDepartment;
    private System.Windows.Forms.SplitContainer splitDepartments;
}
