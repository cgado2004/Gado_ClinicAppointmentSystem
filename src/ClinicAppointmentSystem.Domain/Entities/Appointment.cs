using ClinicAppointmentSystem.Domain.Enums;

namespace ClinicAppointmentSystem.Domain.Entities;

/// <summary>
/// A scheduled appointment between one Patient and one Doctor.
///
/// Relationships:
///   • Patient 1 ──── 0..* Appointment — ASSOCIATION (Rules 1, 2)
///   • Doctor  1 ──── 0..* Appointment — ASSOCIATION (Rules 3, 4)
///
/// BUSINESS RULE 10:
/// "An Appointment records the date, time, and status of the appointment."
///
/// Note both ends are plain ASSOCIATIONS, not compositions. An Appointment has
/// its own identity and lifecycle — it is scheduled, completed, or cancelled
/// independently of the people involved.
/// </summary>
public class Appointment
{
    public int AppointmentId { get; private set; }

    /// <summary>RULE 2 — exactly one patient. Never null.</summary>
    public Patient Patient { get; }

    /// <summary>RULE 4 — exactly one doctor. Never null.</summary>
    public Doctor Doctor { get; }

    // --- Rule 10: the three mandated attributes ---
    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public AppointmentStatus Status { get; private set; }

    public string Reason { get; set; } = string.Empty;

    internal Appointment(
        int appointmentId,
        Patient patient,
        Doctor doctor,
        DateTime date,
        TimeSpan time,
        string reason = "")
    {
        AppointmentId = appointmentId;
        Patient = patient ?? throw new ArgumentNullException(nameof(patient));
        Doctor  = doctor  ?? throw new ArgumentNullException(nameof(doctor));
        Date    = date;
        Time    = time;
        Reason  = reason;
        Status  = AppointmentStatus.Scheduled;   // initial state
    }

    public void Schedule()
    {
        if (Status != AppointmentStatus.Cancelled)
            throw new InvalidOperationException(
                $"Only a cancelled appointment can be re-scheduled. Current status: {Status}.");

        Status = AppointmentStatus.Scheduled;
    }

    public void Cancel()
    {
        if (Status == AppointmentStatus.Completed)
            throw new InvalidOperationException("A completed appointment cannot be cancelled.");

        Status = AppointmentStatus.Cancelled;
    }

    public void Complete()
    {
        if (Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException(
                $"Only a scheduled appointment can be completed. Current status: {Status}.");

        Status = AppointmentStatus.Completed;
    }

    public void MarkNoShow()
    {
        if (Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException(
                $"Only a scheduled appointment can be marked as a no-show. Current status: {Status}.");

        Status = AppointmentStatus.NoShow;
    }

    public void Reschedule(DateTime newDate, TimeSpan newTime)
    {
        if (Status != AppointmentStatus.Scheduled)
            throw new InvalidOperationException(
                $"Only a scheduled appointment can be rescheduled. Current status: {Status}.");

        Date = newDate;
        Time = newTime;
    }

    public override string ToString() =>
        $"Appointment #{AppointmentId}: {Patient.GetFullName()} with {Doctor.GetFullName()} " +
        $"on {Date:yyyy-MM-dd} at {Time:hh\\:mm} [{Status}]";
}
