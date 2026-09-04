using ClinicAppointmentSystem.Domain.Entities;

namespace ClinicAppointmentSystem.WinForms.Forms;

/// <summary>
/// Dialog for adding a doctor.
///
/// RULE 11 — AGGREGATION: the department dropdown includes "(none)". A doctor
/// can be created with no department and remains perfectly valid. That is the
/// difference from composition, where the part cannot exist alone.
/// </summary>
public partial class DoctorForm : Form
{
    private readonly IReadOnlyList<Department> _departments;

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Specialization { get; private set; } = string.Empty;
    public string ContactNumber { get; private set; } = string.Empty;
    public Department? SelectedDepartment { get; private set; }

    public DoctorForm(IReadOnlyList<Department> departments)
    {
        InitializeComponent();
        _departments = departments;
    }

    private void DoctorForm_Load(object sender, EventArgs e)
    {
        // Specializations named in the problem statement.
        cmbSpecialization.Items.AddRange(new object[]
        {
            "General Medicine",
            "Pediatrics",
            "Internal Medicine"
        });
        cmbSpecialization.SelectedIndex = 0;

        // Rule 11: "(none)" is a legitimate choice — a doctor exists
        // independently of any department.
        cmbDepartment.Items.Add("(none — unassigned)");
        foreach (var dept in _departments)
            cmbDepartment.Items.Add(dept.Name);

        cmbDepartment.SelectedIndex = _departments.Count > 0 ? 1 : 0;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;

        FirstName      = txtFirstName.Text.Trim();
        LastName       = txtLastName.Text.Trim();
        Specialization = cmbSpecialization.Text.Trim();
        ContactNumber  = txtContact.Text.Trim();

        // index 0 is "(none)", so real departments start at index 1
        SelectedDepartment = cmbDepartment.SelectedIndex > 0
            ? _departments[cmbDepartment.SelectedIndex - 1]
            : null;

        DialogResult = DialogResult.OK;
        Close();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            ShowError("First name is required.", txtFirstName);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            ShowError("Last name is required.", txtLastName);
            return false;
        }

        if (string.IsNullOrWhiteSpace(cmbSpecialization.Text))
        {
            ShowError("Specialization is required.", cmbSpecialization);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtContact.Text))
        {
            ShowError("Contact number is required.", txtContact);
            return false;
        }

        return true;
    }

    private void ShowError(string message, Control focus)
    {
        MessageBox.Show(message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
    }

    private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
    {
        bool allowed = char.IsControl(e.KeyChar)
                       || char.IsDigit(e.KeyChar)
                       || e.KeyChar is '+' or '-' or ' ';

        if (!allowed)
            e.Handled = true;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
