namespace ClinicAppointmentSystem.WinForms.Forms;

/// <summary>
/// Dialog for registering a new patient.
///
/// Note there is no MedicalRecord input here — Rule 9 means the record is
/// created automatically by the Patient constructor. The UI cannot create one
/// separately even if it wanted to; the constructor is internal.
/// </summary>
public partial class PatientForm : Form
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public string Gender { get; private set; } = string.Empty;
    public string ContactNumber { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;

    public PatientForm()
    {
        InitializeComponent();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateInput())
            return;   // DialogResult stays None, so the dialog stays open

        FirstName     = txtFirstName.Text.Trim();
        LastName      = txtLastName.Text.Trim();
        DateOfBirth   = dtpDateOfBirth.Value;
        Gender        = radMale.Checked ? "Male" : radFemale.Checked ? "Female" : "Other";
        ContactNumber = txtContact.Text.Trim();
        Address       = txtAddress.Text.Trim();

        DialogResult = DialogResult.OK;
        Close();
    }

    /// <summary>
    /// Validates every field before accepting. Returns false and focuses the
    /// offending control so the user is taken straight to the problem.
    /// </summary>
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

        if (dtpDateOfBirth.Value.Date > DateTime.Today)
        {
            ShowError("Date of birth cannot be in the future.", dtpDateOfBirth);
            return false;
        }

        if (dtpDateOfBirth.Value.Date < DateTime.Today.AddYears(-130))
        {
            ShowError("Please check the date of birth — that age is not plausible.", dtpDateOfBirth);
            return false;
        }

        string contact = txtContact.Text.Trim();
        if (string.IsNullOrWhiteSpace(contact))
        {
            ShowError("Contact number is required.", txtContact);
            return false;
        }

        if (!contact.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == ' '))
        {
            ShowError("Contact number may only contain digits, spaces, + and -.", txtContact);
            return false;
        }

        return true;
    }

    private void ShowError(string message, Control focus)
    {
        MessageBox.Show(message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        focus.Focus();
        if (focus is TextBox tb) tb.SelectAll();
    }

    /// <summary>
    /// Rejects non-numeric keystrokes in the contact field as they are typed.
    /// e.Handled = true swallows the keypress entirely.
    /// </summary>
    private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
    {
        bool allowed = char.IsControl(e.KeyChar)     // Backspace, Delete
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
