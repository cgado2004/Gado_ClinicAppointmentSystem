using ClinicAppointmentSystem.Domain.Entities;

namespace ClinicAppointmentSystem.WinForms.Forms;

/// <summary>
/// Views and edits a patient's medical record.
///
/// RULE 9 — COMPOSITION. Note the constructor takes a <see cref="Patient"/>,
/// not a MedicalRecord. You cannot open a record without its owner, because a
/// record has no independent existence. The record is reached through
/// <c>patient.MedicalRecord</c>.
/// </summary>
public partial class MedicalRecordForm : Form
{
    private readonly Patient _patient;

    public MedicalRecordForm(Patient patient)
    {
        InitializeComponent();
        _patient = patient ?? throw new ArgumentNullException(nameof(patient));
    }

    private void MedicalRecordForm_Load(object sender, EventArgs e)
    {
        var record = _patient.MedicalRecord;

        Text = $"Medical Record — {_patient.GetFullName()}";

        lblPatientValue.Text = $"{_patient.GetFullName()}  (Patient #{_patient.PatientId})";
        lblRecordValue.Text  = $"Record #{record.RecordId}";
        lblUpdatedValue.Text = record.LastUpdated.ToString("yyyy-MM-dd HH:mm");

        cmbBloodType.Items.AddRange(new object[]
        {
            "", "A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"
        });
        cmbBloodType.SelectedItem = record.BloodType;
        if (cmbBloodType.SelectedIndex < 0) cmbBloodType.SelectedIndex = 0;

        txtAllergies.Text = record.Allergies;
        txtHistory.Text   = record.ViewHistory();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        _patient.MedicalRecord.UpdateRecord(
            cmbBloodType.Text.Trim(),
            txtAllergies.Text.Trim());

        lblUpdatedValue.Text = _patient.MedicalRecord.LastUpdated.ToString("yyyy-MM-dd HH:mm");

        MessageBox.Show("Medical record updated.", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnAddEntry_Click(object sender, EventArgs e)
    {
        string note = txtNewEntry.Text.Trim();

        if (string.IsNullOrWhiteSpace(note))
        {
            MessageBox.Show("Please type a note before adding it.", "Nothing to add",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNewEntry.Focus();
            return;
        }

        try
        {
            _patient.MedicalRecord.AddEntry(note);

            txtHistory.Text = _patient.MedicalRecord.ViewHistory();
            txtNewEntry.Clear();
            lblUpdatedValue.Text = _patient.MedicalRecord.LastUpdated.ToString("yyyy-MM-dd HH:mm");

            // scroll to the newest entry
            txtHistory.SelectionStart = txtHistory.Text.Length;
            txtHistory.ScrollToCaret();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Invalid entry",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnClose_Click(object sender, EventArgs e) => Close();
}
