namespace ClinicAppointmentSystem.WinForms.Forms;

/// <summary>Dialog for adding a department.</summary>
public partial class DepartmentForm : Form
{
    public string DepartmentName { get; private set; } = string.Empty;
    public string Location { get; private set; } = string.Empty;

    public DepartmentForm()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBox.Show("Department name is required.", "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtName.Focus();
            return;
        }

        DepartmentName = txtName.Text.Trim();
        Location = txtLocation.Text.Trim();

        DialogResult = DialogResult.OK;
        Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
