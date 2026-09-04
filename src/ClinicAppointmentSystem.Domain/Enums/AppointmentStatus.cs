namespace ClinicAppointmentSystem.Domain.Enums;

/// <summary>
/// Status of an appointment. Business Rule 10 requires an appointment to
/// record its status. An enumeration is used instead of a free-text string so
/// that invalid states cannot be represented.
/// </summary>
public enum AppointmentStatus
{
    Scheduled,
    Completed,
    Cancelled,
    NoShow
}
