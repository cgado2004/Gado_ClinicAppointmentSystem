namespace ClinicAppointmentSystem.WinForms.Forms;

partial class DoctorForm
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
        this.lblSpecialization = new System.Windows.Forms.Label();
        this.cmbSpecialization = new System.Windows.Forms.ComboBox();
        this.lblContact = new System.Windows.Forms.Label();
        this.txtContact = new System.Windows.Forms.TextBox();
        this.lblDepartment = new System.Windows.Forms.Label();
        this.cmbDepartment = new System.Windows.Forms.ComboBox();
        this.lblNote = new System.Windows.Forms.Label();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
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

        this.lblSpecialization.AutoSize = true;
        this.lblSpecialization.Location = new System.Drawing.Point(24, 104);
        this.lblSpecialization.Name = "lblSpecialization";
        this.lblSpecialization.Size = new System.Drawing.Size(105, 20);
        this.lblSpecialization.TabIndex = 4;
        this.lblSpecialization.Text = "Specialization:";

        this.cmbSpecialization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
        this.cmbSpecialization.Location = new System.Drawing.Point(160, 101);
        this.cmbSpecialization.Name = "cmbSpecialization";
        this.cmbSpecialization.Size = new System.Drawing.Size(280, 28);
        this.cmbSpecialization.TabIndex = 5;

        this.lblContact.AutoSize = true;
        this.lblContact.Location = new System.Drawing.Point(24, 143);
        this.lblContact.Name = "lblContact";
        this.lblContact.Size = new System.Drawing.Size(119, 20);
        this.lblContact.TabIndex = 6;
        this.lblContact.Text = "Contact number:";

        this.txtContact.Location = new System.Drawing.Point(160, 140);
        this.txtContact.MaxLength = 15;
        this.txtContact.Name = "txtContact";
        this.txtContact.PlaceholderText = "09XXXXXXXXX";
        this.txtContact.Size = new System.Drawing.Size(280, 27);
        this.txtContact.TabIndex = 7;
        this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress);

        this.lblDepartment.AutoSize = true;
        this.lblDepartment.Location = new System.Drawing.Point(24, 182);
        this.lblDepartment.Name = "lblDepartment";
        this.lblDepartment.Size = new System.Drawing.Size(90, 20);
        this.lblDepartment.TabIndex = 8;
        this.lblDepartment.Text = "Department:";

        this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbDepartment.Location = new System.Drawing.Point(160, 179);
        this.cmbDepartment.Name = "cmbDepartment";
        this.cmbDepartment.Size = new System.Drawing.Size(280, 28);
        this.cmbDepartment.TabIndex = 9;

        this.lblNote.ForeColor = System.Drawing.Color.FromArgb(90, 107, 130);
        this.lblNote.Location = new System.Drawing.Point(24, 218);
        this.lblNote.Name = "lblNote";
        this.lblNote.Size = new System.Drawing.Size(416, 44);
        this.lblNote.TabIndex = 10;
        this.lblNote.Text = "Rule 11: a doctor may be left unassigned. Doctors exist independently " +
                            "of departments and survive if one is dissolved.";

        this.btnSave.Location = new System.Drawing.Point(240, 272);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(95, 36);
        this.btnSave.TabIndex = 11;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(345, 272);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(95, 36);
        this.btnCancel.TabIndex = 12;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        this.AcceptButton = this.btnSave;
        this.CancelButton = this.btnCancel;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(464, 328);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblNote);
        this.Controls.Add(this.cmbDepartment);
        this.Controls.Add(this.lblDepartment);
        this.Controls.Add(this.txtContact);
        this.Controls.Add(this.lblContact);
        this.Controls.Add(this.cmbSpecialization);
        this.Controls.Add(this.lblSpecialization);
        this.Controls.Add(this.txtLastName);
        this.Controls.Add(this.lblLastName);
        this.Controls.Add(this.txtFirstName);
        this.Controls.Add(this.lblFirstName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "DoctorForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Add Doctor";
        this.Load += new System.EventHandler(this.DoctorForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblFirstName;
    private System.Windows.Forms.TextBox txtFirstName;
    private System.Windows.Forms.Label lblLastName;
    private System.Windows.Forms.TextBox txtLastName;
    private System.Windows.Forms.Label lblSpecialization;
    private System.Windows.Forms.ComboBox cmbSpecialization;
    private System.Windows.Forms.Label lblContact;
    private System.Windows.Forms.TextBox txtContact;
    private System.Windows.Forms.Label lblDepartment;
    private System.Windows.Forms.ComboBox cmbDepartment;
    private System.Windows.Forms.Label lblNote;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
}
