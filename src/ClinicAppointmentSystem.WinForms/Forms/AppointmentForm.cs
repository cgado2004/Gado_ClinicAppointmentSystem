using ClinicAppointmentSystem.Domain.Entities;
using ClinicAppointmentSystem.WinForms.Data;

namespace ClinicAppointmentSystem.WinForms.Forms;

/// <summary>
/// Dialog for booking an appointment.
///
/// Rules 1–4: exactly one patient and exactly one doctor per appointment, so
/// both are single-selection dropdowns rather than multi-select lists.
/// Rule 10: date, time and status are recorded — status starts as Scheduled.
/// </summary>
public partial class AppointmentForm : Form
{
    private readonly ClinicRepository _repository;

    public AppointmentForm(ClinicRepository repository)
    {
        InitializeComponent();
        _repository = repository;
    }

    private void AppointmentForm_Load(object sender, EventArgs e)
    {
        // Rule 2: exactly one patient
        foreach (var patient in _repository.Patients)
            cmbPatient.Items.Add($"#{patient.PatientId} — {patient.GetFullName()}");

        // Rule 4: exactly one doctor
        foreach (var doctor in _repository.Doctors)
            cmbDoctor.Items.Add($"#{doctor.DoctorId} — {doctor.GetFullName()} ({doctor.Specialization})");

        if (cmbPatient.Items.Count > 0) cmbPatient.SelectedIndex = 0;
        if (cmbDoctor.Items.Count > 0) cmbDoctor.SelectedIndex = 0;

        dtpDate.MinDate = DateTime.Today;
        dtpDate.Value = DateTime.Today.AddDays(1);

        // Clinic hours: 08:00–17:00 on the half hour
        for (int hour = 8; hour <= 16; hour++)
        {
            cmbTime.Items.Add($"{hour:00}:00");
            cmbTime.Items.Add($"{hour:00}:30");
        }
        cmbTime.Items.Add("17:00");
        cmbTime.SelectedIndex = 2;
    }

    private void btnBook_Click(object sender, EventArgs e)
    {
        if (cmbPatient.SelectedIndex < 0)
        {
            MessageBox.Show("Please select a patient.", "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cmbDoctor.SelectedIndex < 0)
        {
            MessageBox.Show("Please select a doctor.", "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cmbTime.SelectedIndex < 0)
        {
            MessageBox.Show("Please select a time.", "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtReason.Text))
        {
            MessageBox.Show("Please give a reason for the appointment.", "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtReason.Focus();
            return;
        }

        Patient patient = _repository.Patients[cmbPatient.SelectedIndex];
        Doctor doctor = _repository.Doctors[cmbDoctor.SelectedIndex];

        // TryParse rather than Parse — never trust a string conversion.
        if (!TimeSpan.TryParse(cmbTime.Text, out TimeSpan time))
        {
            MessageBox.Show("The selected time is not valid.", "Invalid input",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var appointment = _repository.BookAppointment(
            patient, doctor, dtpDate.Value.Date, time, txtReason.Text.Trim());

        if (appointment is null)
        {
            MessageBox.Show(
                $"{doctor.GetFullName()} is already booked at " +
                $"{dtpDate.Value:yyyy-MM-dd} {cmbTime.Text}.\n\nPlease choose another slot.",
                "Slot unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }

    /// <summary>Warns immediately if the chosen doctor/date/time is taken.</summary>
    private void Slot_Changed(object sender, EventArgs e)
    {
        if (cmbDoctor.SelectedIndex < 0 || cmbTime.SelectedIndex < 0)
            return;

        Doctor doctor = _repository.Doctors[cmbDoctor.SelectedIndex];

        if (TimeSpan.TryParse(cmbTime.Text, out TimeSpan time) &&
            _repository.IsDoctorBooked(doctor, dtpDate.Value.Date, time))
        {
            lblAvailability.Text = "⚠ This slot is already booked.";
            lblAvailability.ForeColor = System.Drawing.Color.FromArgb(160, 40, 40);
        }
        else
        {
            lblAvailability.Text = "✓ Slot available.";
            lblAvailability.ForeColor = System.Drawing.Color.FromArgb(29, 92, 70);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
