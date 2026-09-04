namespace ClinicAppointmentSystem.WinForms.Forms;

partial class DepartmentForm
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
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.lblLocation = new System.Windows.Forms.Label();
        this.txtLocation = new System.Windows.Forms.TextBox();
        this.lblNote = new System.Windows.Forms.Label();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();

        this.lblName.AutoSize = true;
        this.lblName.Location = new System.Drawing.Point(24, 26);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(49, 20);
        this.lblName.TabIndex = 0;
        this.lblName.Text = "Name:";

        this.txtName.Location = new System.Drawing.Point(120, 23);
        this.txtName.MaxLength = 100;
        this.txtName.Name = "txtName";
        this.txtName.PlaceholderText = "e.g. Pediatrics";
        this.txtName.Size = new System.Drawing.Size(300, 27);
        this.txtName.TabIndex = 1;

        this.lblLocation.AutoSize = true;
        this.lblLocation.Location = new System.Drawing.Point(24, 65);
        this.lblLocation.Name = "lblLocation";
        this.lblLocation.Size = new System.Drawing.Size(68, 20);
        this.lblLocation.TabIndex = 2;
        this.lblLocation.Text = "Location:";

        this.txtLocation.Location = new System.Drawing.Point(120, 62);
        this.txtLocation.MaxLength = 255;
        this.txtLocation.Name = "txtLocation";
        this.txtLocation.PlaceholderText = "e.g. Second Floor, Wing B";
        this.txtLocation.Size = new System.Drawing.Size(300, 27);
        this.txtLocation.TabIndex = 3;

        this.lblNote.ForeColor = System.Drawing.Color.FromArgb(90, 107, 130);
        this.lblNote.Location = new System.Drawing.Point(24, 102);
        this.lblNote.Name = "lblNote";
        this.lblNote.Size = new System.Drawing.Size(396, 44);
        this.lblNote.TabIndex = 4;
        this.lblNote.Text = "Rule 11: departments aggregate doctors. Removing a department " +
                            "does not delete its doctors — they survive, unassigned.";

        this.btnSave.Location = new System.Drawing.Point(220, 156);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(95, 36);
        this.btnSave.TabIndex = 5;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.Location = new System.Drawing.Point(325, 156);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(95, 36);
        this.btnCancel.TabIndex = 6;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

        this.AcceptButton = this.btnSave;
        this.CancelButton = this.btnCancel;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(444, 212);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.lblNote);
        this.Controls.Add(this.txtLocation);
        this.Controls.Add(this.lblLocation);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblName);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "DepartmentForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Add Department";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblLocation;
    private System.Windows.Forms.TextBox txtLocation;
    private System.Windows.Forms.Label lblNote;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
}
