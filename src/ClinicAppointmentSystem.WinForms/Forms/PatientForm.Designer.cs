namespace ClinicAppointmentSystem.WinForms.Forms;

partial class PatientForm
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
        this.lblFirstName = new System.Windows.Forms.Label();
        this.txtFirstName = new System.Windows.Forms.TextBox();
        this.lblLastName = new System.Windows.Forms.Label();
        this.txtLastName = new System.Windows.Forms.TextBox();
        this.lblDateOfBirth = new System.Windows.Forms.Label();
        this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
        this.grpGender = new System.Windows.Forms.GroupBox();
        this.radMale = new System.Windows.Forms.RadioButton();
        this.radFemale = new System.Windows.Forms.RadioButton();
        this.radOther = new System.Windows.Forms.RadioButton();
        this.lblContact = new System.Windows.Forms.Label();
        this.txtContact = new System.Windows.Forms.TextBox();
        this.lblAddress = new System.Windows.Forms.Label();
        this.txtAddress = new System.Windows.Forms.TextBox();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.lblNote = new System.Windows.Forms.Label();
        this.grpGender.SuspendLayout();
        this.SuspendLayout();

        this.lblFirstName.AutoSize = true;
        this.lblFirstName.Location = new System.Drawing.Point(24, 26);
        this.lblFirstName.Name = "lblFirstName";
        this.lblFirstName.Size = new System.Drawing.Size(82, 20);
        this.lblFirstName.TabIndex = 0;
        this.lblFirstName.Text = "First name:";

        this.txtFirstName.Location = new System.Drawing.Point(160, 23);
        this.txtFirstName.MaxLength = 50;
        this.txtFirstName.Name = "txtFirstName";
        this.txtFirstName.Size = new System.Drawing.Size(280, 27);
        this.txtFirstName.TabIndex = 1;

        this.lblLastName.AutoSize = true;
        this.lblLastName.Location = new System.Drawing.Point(24, 65);
        this.lblLastName.Name = "lblLastName";
        this.lblLastName.Size = new System.Drawing.Size(80, 20);
        this.lblLastName.TabIndex = 2;
        this.lblLastName.Text = "Last name:";

        this.txtLastName.Location = new System.Drawing.Point(160, 62);
        this.txtLastName.MaxLength = 50;
        this.txtLastName.Name = "txtLastName";
        this.txtLastName.Size = new System.Drawing.Size(280, 27);
        this.txtLastName.TabIndex = 3;

        this.lblDateOfBirth.AutoSize = true;
        this.lblDateOfBirth.Location = new System.Drawing.Point(24, 104);
        this.lblDateOfBirth.Name = "lblDateOfBirth";
        this.lblDateOfBirth.Size = new System.Drawing.Size(93, 20);
        this.lblDateOfBirth.TabIndex = 4;
        this.lblDateOfBirth.Text = "Date of birth:";

        this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpDateOfBirth.Location = new System.Drawing.Point(160, 100);
        this.dtpDateOfBirth.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
        this.dtpDateOfBirth.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
        this.dtpDateOfBirth.Name = "dtpDateOfBirth";
        this.dtpDateOfBirth.Size = new System.Drawing.Size(280, 27);
        this.dtpDateOfBirth.TabIndex = 5;
        this.dtpDateOfBirth.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);

        // GroupBox scopes these three radio buttons into one exclusive group.
        this.grpGender.Controls.Add(this.radOther);
        this.grpGender.Controls.Add(this.radFemale);
        this.grpGender.Controls.Add(this.radMale);
        this.grpGender.Location = new System.Drawing.Point(160, 137);
        this.grpGender.Name = "grpGender";
        this.grpGender.Size = new System.Drawing.Size(280, 62);
        this.grpGender.TabIndex = 6;
        this.grpGender.TabStop = false;
        this.grpGender.Text = "Gender";

        this.radMale.AutoSize = true;
        this.radMale.Checked = true;
        this.radMale.Location = new System.Drawing.Point(14, 26);
        this.radMale.Name = "radMale";
        this.radMale.Size = new System.Drawing.Size(64, 24);
        this.radMale.TabIndex = 0;
        this.radMale.TabStop = true;
        this.radMale.Text = "Male";
        this.radMale.UseVisualStyleBackColor = true;

        this.radFemale.AutoSize = true;
        this.radFemale.Location = new System.Drawing.Point(90, 26);
        this.radFemale.Name = "radFemale";
        this.radFemale.Size = new System.Drawing.Size(83, 24);
        this.radFemale.TabIndex = 1;
        this.radFemale.Text = "Female";
        this.radFemale.UseVisualStyleBackColor = true;

        this.radOther.AutoSize = true;
        this.radOther.Location = new System.Drawing.Point(185, 26);
        this.radOther.Name = "radOther";
        this.radOther.Size = new System.Drawing.Size(70, 24);
        this.radOther.TabIndex = 2;
        this.radOther.Text = "Other";
        this.radOther.UseVisualStyleBackColor = true;

        this.lblContact.AutoSize = true;
        this.lblContact.Location = new System.Drawing.Point(24, 216);
        this.lblContact.Name = "lblContact";
        this.lblContact.Size = new System.Drawing.Size(119, 20);
        this.lblContact.TabIndex = 7;
        this.lblContact.Text = "Contact number:";

        this.txtContact.Location = new System.Drawing.Point(160, 213);
        this.txtContact.MaxLength = 15;
        this.txtContact.Name = "txtContact";
        this.txtContact.PlaceholderText = "09XXXXXXXXX";
        this.txtContact.Size = new System.Drawing.Size(280, 27);
        this.txtContact.TabIndex = 8;
        this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress);

        this.lblAddress.AutoSize = true;
        this.lblAddress.Location = new System.Drawing.Point(24, 255);
        this.lblAddress.Name = "lblAddress";
        this.lblAddress.Size = new System.Drawing.Size(65, 20);
        this.lblAddress.TabIndex = 9;
        this.lblAddress.Text = "Address:";

        this.txtAddress.Location = new System.Drawing.Point(160, 252);
        this.txtAddress.MaxLength = 255;
        this.txtAddress.Multiline = true;
        this.txtAddress.Name = "txtAddress";
        this.txtAddress.Size = new System.Drawing.Size(280, 60);
        this.txtAddress.TabIndex = 10;

        this.lblNote.ForeColor = System.Drawing.Color.FromArgb(90, 107, 130);
        this.lblNote.Location = new System.Drawing.Point(24, 322);
        this.lblNote.Name = "lblNote";
        this.lblNote.Size = new System.Drawing.Size(416, 42);
        this.lblNote.TabIndex = 11;
        this.lblNote.Text = "Rule 9: a medical record is created automatically with the patient. " +
                            "It cannot exist independently.";

        this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
        this.btnSave.Location = new System.Drawing.Point(240, 372);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(95, 36);
        this.btnSave.TabIndex = 12;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(345, 372);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(95, 36);
        this.btnCancel.TabIndex = 13;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        this.AcceptButton = this.btnSave;
        this.CancelButton = this.btnCancel;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(464, 428);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblNote);
        this.Controls.Add(this.txtAddress);
        this.Controls.Add(this.lblAddress);
        this.Controls.Add(this.txtContact);
        this.Controls.Add(this.lblContact);
        this.Controls.Add(this.grpGender);
        this.Controls.Add(this.dtpDateOfBirth);
        this.Controls.Add(this.lblDateOfBirth);
        this.Controls.Add(this.txtLastName);
        this.Controls.Add(this.lblLastName);
        this.Controls.Add(this.txtFirstName);
        this.Controls.Add(this.lblFirstName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "PatientForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Register Patient";
        this.grpGender.ResumeLayout(false);
        this.grpGender.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblFirstName;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.Label lblLastName;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label lblDateOfBirth;
    private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
    private System.Windows.Forms.GroupBox grpGender;
    private System.Windows.Forms.RadioButton radMale;
    private System.Windows.Forms.RadioButton radFemale;
    private System.Windows.Forms.RadioButton radOther;
    private System.Windows.Forms.Label lblContact;
    private System.Windows.Forms.TextBox txtContact;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblNote;
}
