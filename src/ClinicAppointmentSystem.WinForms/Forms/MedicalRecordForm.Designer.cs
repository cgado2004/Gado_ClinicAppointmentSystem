namespace ClinicAppointmentSystem.WinForms.Forms;

partial class MedicalRecordForm
{
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
        this.lblPatient = new System.Windows.Forms.Label();
        this.lblPatientValue = new System.Windows.Forms.Label();
        this.lblRecord = new System.Windows.Forms.Label();
        this.lblRecordValue = new System.Windows.Forms.Label();
        this.lblUpdated = new System.Windows.Forms.Label();
        this.lblUpdatedValue = new System.Windows.Forms.Label();
        this.lblBloodType = new System.Windows.Forms.Label();
        this.cmbBloodType = new System.Windows.Forms.ComboBox();
        this.lblAllergies = new System.Windows.Forms.Label();
        this.txtAllergies = new System.Windows.Forms.TextBox();
        this.lblHistory = new System.Windows.Forms.Label();
        this.txtHistory = new System.Windows.Forms.TextBox();
        this.lblNewEntry = new System.Windows.Forms.Label();
        this.txtNewEntry = new System.Windows.Forms.TextBox();
        this.btnAddEntry = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.lblNote = new System.Windows.Forms.Label();
        this.SuspendLayout();

        this.lblPatient.AutoSize = true;
        this.lblPatient.Location = new System.Drawing.Point(24, 22);
        this.lblPatient.Name = "lblPatient";
        this.lblPatient.Size = new System.Drawing.Size(60, 20);
        this.lblPatient.TabIndex = 0;
        this.lblPatient.Text = "Patient:";

        this.lblPatientValue.AutoSize = true;
        this.lblPatientValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblPatientValue.Location = new System.Drawing.Point(140, 22);
        this.lblPatientValue.Name = "lblPatientValue";
        this.lblPatientValue.Size = new System.Drawing.Size(50, 20);
        this.lblPatientValue.TabIndex = 1;
        this.lblPatientValue.Text = "—";

        this.lblRecord.AutoSize = true;
        this.lblRecord.Location = new System.Drawing.Point(24, 50);
        this.lblRecord.Name = "lblRecord";
        this.lblRecord.Size = new System.Drawing.Size(58, 20);
        this.lblRecord.TabIndex = 2;
        this.lblRecord.Text = "Record:";

        this.lblRecordValue.AutoSize = true;
        this.lblRecordValue.Location = new System.Drawing.Point(140, 50);
        this.lblRecordValue.Name = "lblRecordValue";
        this.lblRecordValue.Size = new System.Drawing.Size(50, 20);
        this.lblRecordValue.TabIndex = 3;
        this.lblRecordValue.Text = "—";

        this.lblUpdated.AutoSize = true;
        this.lblUpdated.Location = new System.Drawing.Point(24, 78);
        this.lblUpdated.Name = "lblUpdated";
        this.lblUpdated.Size = new System.Drawing.Size(98, 20);
        this.lblUpdated.TabIndex = 4;
        this.lblUpdated.Text = "Last updated:";

        this.lblUpdatedValue.AutoSize = true;
        this.lblUpdatedValue.Location = new System.Drawing.Point(140, 78);
        this.lblUpdatedValue.Name = "lblUpdatedValue";
        this.lblUpdatedValue.Size = new System.Drawing.Size(50, 20);
        this.lblUpdatedValue.TabIndex = 5;
        this.lblUpdatedValue.Text = "—";

        this.lblBloodType.AutoSize = true;
        this.lblBloodType.Location = new System.Drawing.Point(24, 118);
        this.lblBloodType.Name = "lblBloodType";
        this.lblBloodType.Size = new System.Drawing.Size(84, 20);
        this.lblBloodType.TabIndex = 6;
        this.lblBloodType.Text = "Blood type:";

        this.cmbBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbBloodType.Location = new System.Drawing.Point(140, 115);
        this.cmbBloodType.Name = "cmbBloodType";
        this.cmbBloodType.Size = new System.Drawing.Size(120, 28);
        this.cmbBloodType.TabIndex = 7;

        this.lblAllergies.AutoSize = true;
        this.lblAllergies.Location = new System.Drawing.Point(280, 118);
        this.lblAllergies.Name = "lblAllergies";
        this.lblAllergies.Size = new System.Drawing.Size(68, 20);
        this.lblAllergies.TabIndex = 8;
        this.lblAllergies.Text = "Allergies:";

        this.txtAllergies.Location = new System.Drawing.Point(354, 115);
        this.txtAllergies.MaxLength = 255;
        this.txtAllergies.Name = "txtAllergies";
        this.txtAllergies.Size = new System.Drawing.Size(226, 27);
        this.txtAllergies.TabIndex = 9;

        this.lblHistory.AutoSize = true;
        this.lblHistory.Location = new System.Drawing.Point(24, 158);
        this.lblHistory.Name = "lblHistory";
        this.lblHistory.Size = new System.Drawing.Size(115, 20);
        this.lblHistory.TabIndex = 10;
        this.lblHistory.Text = "Medical history:";

        this.txtHistory.Location = new System.Drawing.Point(24, 182);
        this.txtHistory.Multiline = true;
        this.txtHistory.Name = "txtHistory";
        this.txtHistory.ReadOnly = true;
        this.txtHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtHistory.Size = new System.Drawing.Size(556, 170);
        this.txtHistory.TabIndex = 11;

        this.lblNewEntry.AutoSize = true;
        this.lblNewEntry.Location = new System.Drawing.Point(24, 364);
        this.lblNewEntry.Name = "lblNewEntry";
        this.lblNewEntry.Size = new System.Drawing.Size(78, 20);
        this.lblNewEntry.TabIndex = 12;
        this.lblNewEntry.Text = "New entry:";

        this.txtNewEntry.Location = new System.Drawing.Point(24, 388);
        this.txtNewEntry.MaxLength = 255;
        this.txtNewEntry.Name = "txtNewEntry";
        this.txtNewEntry.PlaceholderText = "e.g. Prescribed amoxicillin 500mg, three times daily for 7 days";
        this.txtNewEntry.Size = new System.Drawing.Size(430, 27);
        this.txtNewEntry.TabIndex = 13;

        this.btnAddEntry.Location = new System.Drawing.Point(462, 386);
        this.btnAddEntry.Name = "btnAddEntry";
        this.btnAddEntry.Size = new System.Drawing.Size(118, 31);
        this.btnAddEntry.TabIndex = 14;
        this.btnAddEntry.Text = "Add Entry";
        this.btnAddEntry.UseVisualStyleBackColor = true;
        this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);

        this.lblNote.ForeColor = System.Drawing.Color.FromArgb(90, 107, 130);
        this.lblNote.Location = new System.Drawing.Point(24, 425);
        this.lblNote.Name = "lblNote";
        this.lblNote.Size = new System.Drawing.Size(360, 44);
        this.lblNote.TabIndex = 15;
        this.lblNote.Text = "Rule 9: this record is reached through its patient. It has no " +
                            "independent existence and is destroyed with them.";

        this.btnSave.Location = new System.Drawing.Point(380, 433);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(95, 36);
        this.btnSave.TabIndex = 16;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

        this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnClose.Location = new System.Drawing.Point(485, 433);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(95, 36);
        this.btnClose.TabIndex = 17;
        this.btnClose.Text = "Close";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

        this.CancelButton = this.btnClose;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(604, 489);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblNote);
        this.Controls.Add(this.btnAddEntry);
        this.Controls.Add(this.txtNewEntry);
        this.Controls.Add(this.lblNewEntry);
        this.Controls.Add(this.txtHistory);
        this.Controls.Add(this.lblHistory);
        this.Controls.Add(this.txtAllergies);
        this.Controls.Add(this.lblAllergies);
        this.Controls.Add(this.cmbBloodType);
        this.Controls.Add(this.lblBloodType);
        this.Controls.Add(this.lblUpdatedValue);
        this.Controls.Add(this.lblUpdated);
        this.Controls.Add(this.lblRecordValue);
        this.Controls.Add(this.lblRecord);
        this.Controls.Add(this.lblPatientValue);
        this.Controls.Add(this.lblPatient);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MedicalRecordForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Medical Record";
        this.Load += new System.EventHandler(this.MedicalRecordForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblPatient;
    private System.Windows.Forms.Label lblPatientValue;
    private System.Windows.Forms.Label lblRecord;
    private System.Windows.Forms.Label lblRecordValue;
    private System.Windows.Forms.Label lblUpdated;
    private System.Windows.Forms.Label lblUpdatedValue;
    private System.Windows.Forms.Label lblBloodType;
    private System.Windows.Forms.ComboBox cmbBloodType;
    private System.Windows.Forms.Label lblAllergies;
    private System.Windows.Forms.TextBox txtAllergies;
    private System.Windows.Forms.Label lblHistory;
    private System.Windows.Forms.TextBox txtHistory;
    private System.Windows.Forms.Label lblNewEntry;
    private System.Windows.Forms.TextBox txtNewEntry;
    private System.Windows.Forms.Button btnAddEntry;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.Label lblNote;
}
