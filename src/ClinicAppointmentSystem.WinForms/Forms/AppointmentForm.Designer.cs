namespace ClinicAppointmentSystem.WinForms.Forms;

partial class AppointmentForm
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
        this.cmbPatient = new System.Windows.Forms.ComboBox();
        this.lblDoctor = new System.Windows.Forms.Label();
        this.cmbDoctor = new System.Windows.Forms.ComboBox();
        this.lblDate = new System.Windows.Forms.Label();
        this.dtpDate = new System.Windows.Forms.DateTimePicker();
        this.lblTime = new System.Windows.Forms.Label();
        this.cmbTime = new System.Windows.Forms.ComboBox();
        this.lblReason = new System.Windows.Forms.Label();
        this.txtReason = new System.Windows.Forms.TextBox();
        this.lblAvailability = new System.Windows.Forms.Label();
        this.lblStatusNote = new System.Windows.Forms.Label();
        this.btnBook = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.lblPatient.AutoSize = true;
        this.lblPatient.Location = new System.Drawing.Point(24, 26);
        this.lblPatient.Name = "lblPatient";
        this.lblPatient.Size = new System.Drawing.Size(60, 20);
        this.lblPatient.TabIndex = 0;
        this.lblPatient.Text = "Patient:";

        this.cmbPatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbPatient.Location = new System.Drawing.Point(130, 23);
        this.cmbPatient.Name = "cmbPatient";
        this.cmbPatient.Size = new System.Drawing.Size(370, 28);
        this.cmbPatient.TabIndex = 1;

        this.lblDoctor.AutoSize = true;
        this.lblDoctor.Location = new System.Drawing.Point(24, 65);
        this.lblDoctor.Name = "lblDoctor";
        this.lblDoctor.Size = new System.Drawing.Size(57, 20);
        this.lblDoctor.TabIndex = 2;
        this.lblDoctor.Text = "Doctor:";

        this.cmbDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbDoctor.Location = new System.Drawing.Point(130, 62);
        this.cmbDoctor.Name = "cmbDoctor";
        this.cmbDoctor.Size = new System.Drawing.Size(370, 28);
        this.cmbDoctor.TabIndex = 3;
        this.cmbDoctor.SelectedIndexChanged += new System.EventHandler(this.Slot_Changed);

        this.lblDate.AutoSize = true;
        this.lblDate.Location = new System.Drawing.Point(24, 104);
        this.lblDate.Name = "lblDate";
        this.lblDate.Size = new System.Drawing.Size(42, 20);
        this.lblDate.TabIndex = 4;
        this.lblDate.Text = "Date:";

        this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpDate.Location = new System.Drawing.Point(130, 100);
        this.dtpDate.Name = "dtpDate";
        this.dtpDate.Size = new System.Drawing.Size(200, 27);
        this.dtpDate.TabIndex = 5;
        this.dtpDate.ValueChanged += new System.EventHandler(this.Slot_Changed);

        this.lblTime.AutoSize = true;
        this.lblTime.Location = new System.Drawing.Point(346, 104);
        this.lblTime.Name = "lblTime";
        this.lblTime.Size = new System.Drawing.Size(44, 20);
        this.lblTime.TabIndex = 6;
        this.lblTime.Text = "Time:";

        this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbTime.Location = new System.Drawing.Point(396, 100);
        this.cmbTime.Name = "cmbTime";
        this.cmbTime.Size = new System.Drawing.Size(104, 28);
        this.cmbTime.TabIndex = 7;
        this.cmbTime.SelectedIndexChanged += new System.EventHandler(this.Slot_Changed);

        this.lblAvailability.Location = new System.Drawing.Point(130, 134);
        this.lblAvailability.Name = "lblAvailability";
        this.lblAvailability.Size = new System.Drawing.Size(370, 24);
        this.lblAvailability.TabIndex = 8;
        this.lblAvailability.Text = "";

        this.lblReason.AutoSize = true;
        this.lblReason.Location = new System.Drawing.Point(24, 168);
        this.lblReason.Name = "lblReason";
        this.lblReason.Size = new System.Drawing.Size(60, 20);
        this.lblReason.TabIndex = 9;
        this.lblReason.Text = "Reason:";

        this.txtReason.Location = new System.Drawing.Point(130, 165);
        this.txtReason.MaxLength = 255;
        this.txtReason.Multiline = true;
        this.txtReason.Name = "txtReason";
        this.txtReason.Size = new System.Drawing.Size(370, 70);
        this.txtReason.TabIndex = 10;

        this.lblStatusNote.ForeColor = System.Drawing.Color.FromArgb(90, 107, 130);
        this.lblStatusNote.Location = new System.Drawing.Point(24, 245);
        this.lblStatusNote.Name = "lblStatusNote";
        this.lblStatusNote.Size = new System.Drawing.Size(476, 26);
        this.lblStatusNote.TabIndex = 11;
        this.lblStatusNote.Text = "Rule 10: date, time and status are recorded. New appointments start as 'Scheduled'.";

        this.btnBook.Location = new System.Drawing.Point(300, 281);
        this.btnBook.Name = "btnBook";
        this.btnBook.Size = new System.Drawing.Size(95, 36);
        this.btnBook.TabIndex = 12;
        this.btnBook.Text = "Book";
        this.btnBook.UseVisualStyleBackColor = true;
        this.btnBook.Click += new System.EventHandler(this.btnBook_Click);

        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(405, 281);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(95, 36);
        this.btnCancel.TabIndex = 13;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        this.AcceptButton = this.btnBook;
        this.CancelButton = this.btnCancel;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(524, 337);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnBook);
        this.Controls.Add(this.lblStatusNote);
        this.Controls.Add(this.txtReason);
        this.Controls.Add(this.lblReason);
        this.Controls.Add(this.lblAvailability);
        this.Controls.Add(this.cmbTime);
        this.Controls.Add(this.lblTime);
        this.Controls.Add(this.dtpDate);
        this.Controls.Add(this.lblDate);
        this.Controls.Add(this.cmbDoctor);
        this.Controls.Add(this.lblDoctor);
        this.Controls.Add(this.cmbPatient);
        this.Controls.Add(this.lblPatient);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AppointmentForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Book Appointment";
        this.Load += new System.EventHandler(this.AppointmentForm_Load);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblPatient;
    private System.Windows.Forms.ComboBox cmbPatient;
    private System.Windows.Forms.Label lblDoctor;
    private System.Windows.Forms.ComboBox cmbDoctor;
    private System.Windows.Forms.Label lblDate;
    private System.Windows.Forms.DateTimePicker dtpDate;
    private System.Windows.Forms.Label lblTime;
    private System.Windows.Forms.ComboBox cmbTime;
    private System.Windows.Forms.Label lblReason;
    private System.Windows.Forms.TextBox txtReason;
    private System.Windows.Forms.Label lblAvailability;
    private System.Windows.Forms.Label lblStatusNote;
    private System.Windows.Forms.Button btnBook;
    private System.Windows.Forms.Button btnCancel;
}
