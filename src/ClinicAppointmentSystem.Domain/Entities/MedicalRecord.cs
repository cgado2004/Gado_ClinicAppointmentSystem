namespace ClinicAppointmentSystem.Domain.Entities;

/// <summary>
/// A patient's medical record.
///
/// BUSINESS RULE 9 — COMPOSITION:
/// "A MedicalRecord is considered part of the patient's clinic record and does
///  not exist independently in this system."
///
/// This is enforced in code by:
///   1. An <c>internal</c> constructor, so only the Domain assembly (in
///      practice, <see cref="Patient"/>) can create one.
///   2. A required non-null <see cref="Patient"/> back-reference — a record
///      can never exist without an owner.
///
/// Deleting the Patient conceptually destroys this record with it.
/// </summary>
public class MedicalRecord
{
    public int RecordId { get; private set; }

    /// <summary>The owning patient. Never null — see Rule 9.</summary>
    public Patient Patient { get; }

    public string BloodType { get; set; } = string.Empty;
    public string Allergies { get; set; } = string.Empty;
    public string MedicalHistory { get; private set; } = string.Empty;
    public DateTime LastUpdated { get; private set; }

    /// <summary>
    /// Internal by design: a MedicalRecord may only be created by its owning
    /// Patient. This is the composition relationship expressed in code.
    /// </summary>
    internal MedicalRecord(int recordId, Patient patient)
    {
        RecordId = recordId;
        Patient = patient ?? throw new ArgumentNullException(
            nameof(patient),
            "Rule 9: a MedicalRecord cannot exist without a Patient.");
        LastUpdated = DateTime.Now;
    }

    /// <summary>Appends a dated entry to the medical history.</summary>
    public void AddEntry(string note)
    {
        if (string.IsNullOrWhiteSpace(note))
            throw new ArgumentException("Note cannot be empty.", nameof(note));

        MedicalHistory += $"[{DateTime.Now:yyyy-MM-dd}] {note}{Environment.NewLine}";
        LastUpdated = DateTime.Now;
    }

    public void UpdateRecord(string bloodType, string allergies)
    {
        BloodType = bloodType;
        Allergies = allergies;
        LastUpdated = DateTime.Now;
    }

    public string ViewHistory() =>
        string.IsNullOrWhiteSpace(MedicalHistory)
            ? "No medical history on file."
            : MedicalHistory;

    public override string ToString() =>
        $"MedicalRecord #{RecordId} for {Patient.GetFullName()}";
}
