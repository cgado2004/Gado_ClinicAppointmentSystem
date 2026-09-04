namespace ClinicAppointmentSystem.Domain.Entities;

/// <summary>
/// A doctor working at the clinic.
///
/// Relationships:
///   • Department 1 ──◇ 1..* Doctor    — AGGREGATION (Rules 5, 6, 11)
///   • Doctor     1 ──── 0..* Appointment — ASSOCIATION (Rules 3, 4)
///
/// BUSINESS RULE 11 — AGGREGATION:
/// "The clinic has several doctors and departments that operate independently
///  of individual appointments."
///
/// Contrast with <see cref="MedicalRecord"/>: a Doctor is constructed on its
/// own, with a PUBLIC constructor, and can exist with no Department assigned.
/// If a Department is dissolved, the Doctor object survives and can be
/// reassigned. That is aggregation, not composition.
/// </summary>
public class Doctor
{
    private readonly List<Appointment> _appointments = new();

    public int DoctorId { get; private set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// e.g. "General Medicine", "Pediatrics", "Internal Medicine".
    /// An attribute, not a class — nothing in the rules gives it its own
    /// attributes or relationships.
    /// </summary>
    public string Specialization { get; set; } = string.Empty;

    public string ContactNumber { get; set; } = string.Empty;

    /// <summary>
    /// RULE 6 — each doctor belongs to one department.
    /// Nullable because, per Rule 11, a Doctor exists independently: the object
    /// is valid before assignment and survives the department's removal.
    /// </summary>
    public Department? Department { get; internal set; }

    /// <summary>RULE 3 — "zero or many".</summary>
    public IReadOnlyList<Appointment> Appointments => _appointments.AsReadOnly();

    /// <summary>Public constructor — a Doctor stands alone. (Rule 11.)</summary>
    public Doctor(int doctorId, string firstName, string lastName, string specialization)
    {
        DoctorId = doctorId;
        FirstName = firstName;
        LastName = lastName;
        Specialization = specialization;
    }

    public string GetFullName() => $"Dr. {FirstName} {LastName}".Trim();

    internal void AddAppointment(Appointment appointment)
    {
        ArgumentNullException.ThrowIfNull(appointment);
        if (!_appointments.Contains(appointment))
            _appointments.Add(appointment);
    }

    /// <summary>All appointments still scheduled, earliest first.</summary>
    public IEnumerable<Appointment> ViewSchedule() =>
        _appointments
            .Where(a => a.Status == Enums.AppointmentStatus.Scheduled)
            .OrderBy(a => a.Date)
            .ThenBy(a => a.Time);

    /// <summary>Appointments on one specific date.</summary>
    public IEnumerable<Appointment> ViewScheduleFor(DateTime date) =>
        _appointments
            .Where(a => a.Date.Date == date.Date)
            .OrderBy(a => a.Time);

    public override string ToString() =>
        $"Doctor #{DoctorId}: {GetFullName()} ({Specialization})";
}
