namespace ClinicAppointmentSystem.Domain.Entities;

/// <summary>
/// A clinical department, e.g. Pediatrics or Internal Medicine.
///
/// BUSINESS RULE 11 — AGGREGATION (hollow diamond ◇ on this class):
/// "The clinic has several doctors and departments that operate independently
///  of individual appointments."
///
/// Doctors are AGGREGATED, not composed. Key evidence in this code:
///   • <see cref="AddDoctor"/> accepts an ALREADY-CONSTRUCTED Doctor. The
///     Department does not create its parts.
///   • <see cref="RemoveDoctor"/> detaches the Doctor without destroying it.
///   • Disposing of a Department leaves its Doctor objects fully intact.
///
/// Compare <see cref="Patient"/>, which CREATES its MedicalRecord internally
/// and never releases it — that is composition.
/// </summary>
public class Department
{
    private readonly List<Doctor> _doctors = new();

    public int DepartmentId { get; private set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;

    /// <summary>RULE 5 — a department can have many doctors.</summary>
    public IReadOnlyList<Doctor> Doctors => _doctors.AsReadOnly();

    public Department(int departmentId, string name, string location = "")
    {
        DepartmentId = departmentId;
        Name = name;
        Location = location;
    }

    /// <summary>
    /// Assigns an existing Doctor to this department (Rule 6: one department
    /// per doctor). The Doctor is passed in, not created here — aggregation.
    /// </summary>
    public void AddDoctor(Doctor doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        if (_doctors.Contains(doctor))
            return;

        // Rule 6: a doctor belongs to exactly one department, so detach first.
        doctor.Department?.RemoveDoctor(doctor);

        _doctors.Add(doctor);
        doctor.Department = this;
    }

    /// <summary>
    /// Detaches a Doctor. The Doctor object continues to exist — this is the
    /// behavioural difference between aggregation and composition.
    /// </summary>
    public void RemoveDoctor(Doctor doctor)
    {
        ArgumentNullException.ThrowIfNull(doctor);

        if (_doctors.Remove(doctor))
            doctor.Department = null;   // survives, merely unassigned
    }

    public IEnumerable<Doctor> ListDoctors() => _doctors.OrderBy(d => d.LastName);

    public IEnumerable<Doctor> FindBySpecialization(string specialization) =>
        _doctors.Where(d =>
            d.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase));

    public override string ToString() =>
        $"Department #{DepartmentId}: {Name} ({_doctors.Count} doctor(s))";
}
