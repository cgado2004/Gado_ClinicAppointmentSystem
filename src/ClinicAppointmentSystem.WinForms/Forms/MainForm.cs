using ClinicAppointmentSystem.Domain.Entities;
using ClinicAppointmentSystem.Domain.Enums;
using ClinicAppointmentSystem.WinForms.Data;

namespace ClinicAppointmentSystem.WinForms.Forms;

/// <summary>
/// Main window. Four tabs: Patients, Doctors, Appointments, Departments.
///
/// The form is a thin layer — it reads user input, validates it, and calls the
/// domain model. All business rules live in the Domain project, exactly as the
/// class diagram describes. That separation is why the rules can be unit-tested
/// without clicking a single button.
/// </summary>
public partial class MainForm : Form
{
    // FIELD, not a local. It must survive between event handlers — the same
    // reason num1 and operation must be fields in the calculator example.
    private readonly ClinicRepository _repository = new();

    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        PopulateSpecializationFilter();
        RefreshAll();
        SetStatus("Loaded sample data for Tagum City Community Clinic.");
    }

    // =================================================================
    //  Refresh helpers
    // =================================================================
    private void RefreshAll()
    {
        RefreshPatients();
        RefreshDoctors();
        RefreshAppointments();
        RefreshDepartments();
    }

    private void RefreshPatients()
    {
        string search = txtPatientSearch.Text.Trim();

        var rows = _repository.Patients
            .Where(p => string.IsNullOrEmpty(search) ||
                        p.GetFullName().Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        p.ContactNumber.Contains(search, StringComparison.OrdinalIgnoreCase))
            .Select(p => new
            {
                ID           = p.PatientId,
                Name         = p.GetFullName(),
                Age          = CalculateAge(p.DateOfBirth),
                p.Gender,
                Contact      = p.ContactNumber,
                p.Address,
                Appointments = p.Appointments.Count,
                BloodType    = p.MedicalRecord.BloodType
            })
            .ToList();

        dgvPatients.DataSource = rows;
    }

    private void RefreshDoctors()
    {
        string? filter = cmbFilterSpecialization.SelectedItem?.ToString();

        var rows = _repository.Doctors
            .Where(d => string.IsNullOrEmpty(filter) ||
                        filter == "(All specializations)" ||
                        d.Specialization == filter)
            .Select(d => new
            {
                ID             = d.DoctorId,
                Name           = d.GetFullName(),
                d.Specialization,
                // Rule 11: a doctor with no department is still a valid doctor.
                Department     = d.Department?.Name ?? "(unassigned)",
                Contact        = d.ContactNumber,
                Scheduled      = d.Appointments.Count(a => a.Status == AppointmentStatus.Scheduled)
            })
            .ToList();

        dgvDoctors.DataSource = rows;
    }

    private void RefreshAppointments()
    {
        IEnumerable<Appointment> source = _repository.AllAppointments;

        if (radScheduled.Checked)
            source = source.Where(a => a.Status == AppointmentStatus.Scheduled);
        else if (radCompleted.Checked)
            source = source.Where(a => a.Status == AppointmentStatus.Completed);
        else if (radCancelled.Checked)
            source = source.Where(a => a.Status == AppointmentStatus.Cancelled);

        var rows = source
            .OrderByDescending(a => a.Date)
            .ThenBy(a => a.Time)
            .Select(a => new
            {
                ID      = a.AppointmentId,
                Patient = a.Patient.GetFullName(),
                Doctor  = a.Doctor.GetFullName(),
                Date    = a.Date.ToString("yyyy-MM-dd"),
                Time    = a.Time.ToString(@"hh\:mm"),
                Status  = a.Status.ToString(),
                a.Reason
            })
            .ToList();

        dgvAppointments.DataSource = rows;
    }

    private void RefreshDepartments()
    {
        var rows = _repository.Departments
            .Select(d => new
            {
                ID      = d.DepartmentId,
                d.Name,
                d.Location,
                Doctors = d.Doctors.Count
            })
            .ToList();

        dgvDepartments.DataSource = rows;
        RefreshDepartmentDoctors();
    }

    private void RefreshDepartmentDoctors()
    {
        lstDepartmentDoctors.Items.Clear();

        var dept = GetSelectedDepartment();
        if (dept is null)
        {
            lblDeptDoctors.Text = "Doctors in department";
            return;
        }

        lblDeptDoctors.Text = $"Doctors in {dept.Name}";

        foreach (var doctor in dept.ListDoctors())
            lstDepartmentDoctors.Items.Add($"{doctor.GetFullName()} — {doctor.Specialization}");

        if (lstDepartmentDoctors.Items.Count == 0)
            lstDepartmentDoctors.Items.Add("(no doctors assigned)");
    }

    private void PopulateSpecializationFilter()
    {
        cmbFilterSpecialization.Items.Clear();
        cmbFilterSpecialization.Items.Add("(All specializations)");

        foreach (var spec in _repository.Doctors
                     .Select(d => d.Specialization)
                     .Distinct()
                     .OrderBy(s => s))
        {
            cmbFilterSpecialization.Items.Add(spec);
        }

        cmbFilterSpecialization.SelectedIndex = 0;
    }

    // =================================================================
    //  Selection helpers — return null when nothing valid is selected
    // =================================================================
    private Patient? GetSelectedPatient()
    {
        if (dgvPatients.CurrentRow is null) return null;

        int id = (int)dgvPatients.CurrentRow.Cells["ID"].Value;
        return _repository.Patients.FirstOrDefault(p => p.PatientId == id);
    }

    private Doctor? GetSelectedDoctor()
    {
        if (dgvDoctors.CurrentRow is null) return null;

        int id = (int)dgvDoctors.CurrentRow.Cells["ID"].Value;
        return _repository.Doctors.FirstOrDefault(d => d.DoctorId == id);
    }

    private Appointment? GetSelectedAppointment()
    {
        if (dgvAppointments.CurrentRow is null) return null;

        int id = (int)dgvAppointments.CurrentRow.Cells["ID"].Value;
        return _repository.AllAppointments.FirstOrDefault(a => a.AppointmentId == id);
    }

    private Department? GetSelectedDepartment()
    {
        if (dgvDepartments.CurrentRow is null) return null;

        int id = (int)dgvDepartments.CurrentRow.Cells["ID"].Value;
        return _repository.Departments.FirstOrDefault(d => d.DepartmentId == id);
    }

    // =================================================================
    //  Patients tab
    // =================================================================
    private void btnAddPatient_Click(object sender, EventArgs e)
    {
        using var dialog = new PatientForm();

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        var patient = _repository.AddPatient(
            dialog.FirstName, dialog.LastName, dialog.DateOfBirth,
            dialog.Gender, dialog.ContactNumber, dialog.Address);

        RefreshPatients();
        SetStatus($"Registered {patient.GetFullName()} " +
                  $"(medical record #{patient.MedicalRecord.RecordId} created automatically).");
    }

    private void btnViewRecord_Click(object sender, EventArgs e)
    {
        var patient = GetSelectedPatient();
        if (patient is null)
        {
            MessageBox.Show("Please select a patient first.", "No selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialog = new MedicalRecordForm(patient);
        dialog.ShowDialog(this);

        RefreshPatients();
    }

    private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
            btnViewRecord_Click(sender, e);
    }

    /// <summary>
    /// RULE 9 — COMPOSITION demonstration. Deleting the patient destroys the
    /// medical record with them, because the record cannot exist alone.
    /// </summary>
    private void btnDeletePatient_Click(object sender, EventArgs e)
    {
        var patient = GetSelectedPatient();
        if (patient is null)
        {
            MessageBox.Show("Please select a patient first.", "No selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirm = MessageBox.Show(
            $"Delete {patient.GetFullName()}?\n\n" +
            $"RULE 9 — COMPOSITION:\n" +
            $"Medical record #{patient.MedicalRecord.RecordId} will be DESTROYED " +
            $"with the patient. A medical record cannot exist independently.\n\n" +
            $"{patient.Appointments.Count} appointment(s) will also be removed.",
            "Confirm deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirm != DialogResult.Yes)
            return;

        string name = patient.GetFullName();
        _repository.RemovePatient(patient);

        RefreshAll();
        SetStatus($"Deleted {name}. Composition: the medical record was destroyed with the patient.");
    }

    private void txtPatientSearch_TextChanged(object sender, EventArgs e) => RefreshPatients();

    // =================================================================
    //  Doctors tab
    // =================================================================
    private void btnAddDoctor_Click(object sender, EventArgs e)
    {
        using var dialog = new DoctorForm(_repository.Departments);

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        var doctor = _repository.AddDoctor(
            dialog.FirstName, dialog.LastName, dialog.Specialization,
            dialog.ContactNumber, dialog.SelectedDepartment);

        PopulateSpecializationFilter();
        RefreshDoctors();
        RefreshDepartments();
        SetStatus($"Added {doctor.GetFullName()} ({doctor.Specialization}).");
    }

    private void btnViewSchedule_Click(object sender, EventArgs e)
    {
        var doctor = GetSelectedDoctor();
        if (doctor is null)
        {
            MessageBox.Show("Please select a doctor first.", "No selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var schedule = doctor.ViewSchedule().ToList();

        if (schedule.Count == 0)
        {
            MessageBox.Show($"{doctor.GetFullName()} has no scheduled appointments.",
                            "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        string text = string.Join(Environment.NewLine,
            schedule.Select(a =>
                $"{a.Date:yyyy-MM-dd}  {a.Time:hh\\:mm}  —  {a.Patient.GetFullName()}  ({a.Reason})"));

        MessageBox.Show($"Upcoming appointments for {doctor.GetFullName()}:\n\n{text}",
                        "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void cmbFilterSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        => RefreshDoctors();

    // =================================================================
    //  Appointments tab
    // =================================================================
    private void btnBookAppointment_Click(object sender, EventArgs e)
    {
        if (_repository.Patients.Count == 0 || _repository.Doctors.Count == 0)
        {
            MessageBox.Show("You need at least one patient and one doctor before booking.",
                            "Cannot book", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using var dialog = new AppointmentForm(_repository);

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        RefreshAll();
        SetStatus("Appointment booked.");
    }

    private void btnCompleteAppointment_Click(object sender, EventArgs e)
        => ChangeAppointmentStatus(a => a.Complete(), "completed");

    private void btnCancelAppointment_Click(object sender, EventArgs e)
        => ChangeAppointmentStatus(a => a.Cancel(), "cancelled");

    private void btnNoShow_Click(object sender, EventArgs e)
        => ChangeAppointmentStatus(a => a.MarkNoShow(), "marked as no-show");

    /// <summary>
    /// Shared handler for the three status transitions. The domain model
    /// enforces which transitions are legal and throws if one isn't — we catch
    /// that and show the message rather than letting the app crash.
    /// </summary>
    private void ChangeAppointmentStatus(Action<Appointment> action, string verb)
    {
        var appointment = GetSelectedAppointment();
        if (appointment is null)
        {
            MessageBox.Show("Please select an appointment first.", "No selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            action(appointment);
            RefreshAll();
            SetStatus($"Appointment #{appointment.AppointmentId} {verb}.");
        }
        catch (InvalidOperationException ex)
        {
            // The domain model rejected an illegal state transition.
            MessageBox.Show(ex.Message, "Invalid operation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void StatusFilter_CheckedChanged(object sender, EventArgs e)
    {
        // CheckedChanged fires twice per change (one control off, one on).
        // Only respond to the control being switched ON.
        if (sender is RadioButton { Checked: true })
            RefreshAppointments();
    }

    // =================================================================
    //  Departments tab
    // =================================================================
    private void btnAddDepartment_Click(object sender, EventArgs e)
    {
        using var dialog = new DepartmentForm();

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        var dept = _repository.AddDepartment(dialog.DepartmentName, dialog.Location);

        RefreshDepartments();
        SetStatus($"Added department: {dept.Name}.");
    }

    /// <summary>
    /// RULE 11 — AGGREGATION demonstration. Removing a department does NOT
    /// delete its doctors. They survive, unassigned, ready for reassignment.
    /// This is the exact opposite of the Patient/MedicalRecord behaviour.
    /// </summary>
    private void btnRemoveDepartment_Click(object sender, EventArgs e)
    {
        var dept = GetSelectedDepartment();
        if (dept is null)
        {
            MessageBox.Show("Please select a department first.", "No selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        int doctorCount = dept.Doctors.Count;

        var confirm = MessageBox.Show(
            $"Remove the {dept.Name} department?\n\n" +
            $"RULE 11 — AGGREGATION:\n" +
            $"Its {doctorCount} doctor(s) will SURVIVE and become unassigned. " +
            $"They are not deleted — they can be reassigned to another department.\n\n" +
            $"Contrast this with deleting a patient, which destroys their medical record.",
            "Confirm removal",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirm != DialogResult.Yes)
            return;

        string name = dept.Name;
        _repository.RemoveDepartment(dept);

        RefreshAll();
        tabMain.SelectedTab = tabDoctors;   // show the survivors
        SetStatus($"Removed {name}. Aggregation: {doctorCount} doctor(s) survived as '(unassigned)'.");
    }

    private void dgvDepartments_SelectionChanged(object sender, EventArgs e)
        => RefreshDepartmentDoctors();

    // =================================================================
    //  Utilities
    // =================================================================
    private void SetStatus(string message) =>
        lblStatus.Text = $"{DateTime.Now:HH:mm:ss}  —  {message}";

    private static int CalculateAge(DateTime dateOfBirth)
    {
        if (dateOfBirth == default) return 0;

        int age = DateTime.Today.Year - dateOfBirth.Year;
        if (dateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
        return age;
    }
}
