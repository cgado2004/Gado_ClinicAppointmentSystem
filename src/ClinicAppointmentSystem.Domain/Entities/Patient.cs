namespace ClinicAppointmentSystem.Domain.Entities;

/// <summary>
/// A patient of the clinic.
///
/// Relationships:
///   • Patient 1 ──◆ 1  MedicalRecord  — COMPOSITION (Rules 7, 8, 9)
///   • Patient 1 ──── 0..* Appointment — ASSOCIATION (Rules 1, 2)
/// </summary>
public class Patient
{
    private readonly List<Appointment> _appointments = new();

    public int PatientId { get; private set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// RULE 9 — COMPOSITION. The record is created by, and owned by, this
    /// Patient. It is created in the constructor and can never be replaced or
    /// detached, so it cannot outlive its owner.
    /// </summary>
    public MedicalRecord MedicalRecord { get; }

    /// <summary>
    /// RULE 1 — "zero or many". Exposed read-only so callers cannot bypass
    /// <see cref="ScheduleAppointment"/> and corrupt the object graph.
    /// </summary>
    public IReadOnlyList<Appointment> Appointments => _appointments.AsReadOnly();

    public Patient(int patientId, string firstName, string lastName)
    {
        PatientId = patientId;
        FirstName = firstName;
        LastName = lastName;

        // Composition: the part is created with the whole.
        MedicalRecord = new MedicalRecord(patientId, this);
    }

    public string GetFullName() => $"{FirstName} {LastName}".Trim();

    /// <summary>
    /// Schedules an appointment with a doctor. Registers the appointment on
    /// both sides of the association so the object graph stays consistent.
    /// </summary>
    public Appointment ScheduleAppointment(
        int appointmentId, Doctor doctor, DateTime date, TimeSpan time, string reason = "")
    {
        ArgumentNullException.ThrowIfNull(doctor);

        var appointment = new Appointment(appointmentId, this, doctor, date, time, reason);

        _appointments.Add(appointment);
        doctor.AddAppointment(appointment);   // keep both ends in sync

        return appointment;
    }

    public void CancelAppointment(Appointment appointment)
    {
        ArgumentNullException.ThrowIfNull(appointment);

        if (!_appointments.Contains(appointment))
            throw new InvalidOperationException(
                "This appointment does not belong to this patient.");

        appointment.Cancel();
    }

    public MedicalRecord ViewMedicalRecord() => MedicalRecord;

    public override string ToString() => $"Patient #{PatientId}: {GetFullName()}";
}
