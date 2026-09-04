using ClinicAppointmentSystem.Domain.Entities;

namespace ClinicAppointmentSystem.WinForms.Data;

/// <summary>
/// In-memory data store for the clinic.
///
/// This stands in for a database so the UI runs with zero setup. Every object
/// is created through the domain model's own constructors and methods, so all
/// the UML rules (composition, aggregation, multiplicities) are enforced here
/// exactly as they are in the class diagram.
///
/// Swap this class for a MySQL data access layer later and no form changes.
/// </summary>
public class ClinicRepository
{
    private readonly List<Department> _departments = new();
    private readonly List<Doctor> _doctors = new();
    private readonly List<Patient> _patients = new();

    private int _nextPatientId = 1;
    private int _nextDoctorId = 1;
    private int _nextDepartmentId = 1;
    private int _nextAppointmentId = 1;

    public IReadOnlyList<Department> Departments => _departments.AsReadOnly();
    public IReadOnlyList<Doctor> Doctors => _doctors.AsReadOnly();
    public IReadOnlyList<Patient> Patients => _patients.AsReadOnly();

    /// <summary>Every appointment in the clinic, flattened from all patients.</summary>
    public IEnumerable<Appointment> AllAppointments =>
        _patients.SelectMany(p => p.Appointments);

    public ClinicRepository() => SeedSampleData();

    // -----------------------------------------------------------------
    // Departments
    // -----------------------------------------------------------------
    public Department AddDepartment(string name, string location)
    {
        var dept = new Department(_nextDepartmentId++, name, location);
        _departments.Add(dept);
        return dept;
    }

    /// <summary>
    /// RULE 11 — AGGREGATION. Removing a department does NOT delete its
    /// doctors. They are detached and survive, ready to be reassigned.
    /// </summary>
    public void RemoveDepartment(Department department)
    {
        // Detach every doctor first — they outlive the department.
        foreach (var doctor in department.Doctors.ToList())
            department.RemoveDoctor(doctor);

        _departments.Remove(department);
    }

    // -----------------------------------------------------------------
    // Doctors
    // -----------------------------------------------------------------
    public Doctor AddDoctor(string firstName, string lastName, string specialization,
                            string contactNumber, Department? department)
    {
        var doctor = new Doctor(_nextDoctorId++, firstName, lastName, specialization)
        {
            ContactNumber = contactNumber
        };

        _doctors.Add(doctor);
        department?.AddDoctor(doctor);   // Rule 6: assigned to one department
        return doctor;
    }

    // -----------------------------------------------------------------
    // Patients
    // -----------------------------------------------------------------
    /// <summary>
    /// RULE 9 — COMPOSITION. The Patient constructor creates the
    /// MedicalRecord. We never construct one separately; we can't.
    /// </summary>
    public Patient AddPatient(string firstName, string lastName, DateTime dob,
                              string gender, string contactNumber, string address)
    {
        var patient = new Patient(_nextPatientId++, firstName, lastName)
        {
            DateOfBirth = dob,
            Gender = gender,
            ContactNumber = contactNumber,
            Address = address
        };

        _patients.Add(patient);
        return patient;
    }

    /// <summary>
    /// RULE 9 — COMPOSITION. Removing the patient destroys the medical record
    /// with them, because nothing else holds a reference to it.
    /// </summary>
    public void RemovePatient(Patient patient) => _patients.Remove(patient);

    // -----------------------------------------------------------------
    // Appointments
    // -----------------------------------------------------------------
    /// <summary>
    /// Books an appointment through the Patient, which keeps both ends of the
    /// association in sync. Returns null if the doctor is already booked.
    /// </summary>
    public Appointment? BookAppointment(Patient patient, Doctor doctor,
                                        DateTime date, TimeSpan time, string reason)
    {
        if (IsDoctorBooked(doctor, date, time))
            return null;

        return patient.ScheduleAppointment(_nextAppointmentId++, doctor, date, time, reason);
    }

    /// <summary>Prevents double-booking a doctor in the same slot.</summary>
    public bool IsDoctorBooked(Doctor doctor, DateTime date, TimeSpan time) =>
        doctor.Appointments.Any(a =>
            a.Status == Domain.Enums.AppointmentStatus.Scheduled &&
            a.Date.Date == date.Date &&
            a.Time == time);

    // -----------------------------------------------------------------
    // Sample data — Tagum City Community Clinic
    // -----------------------------------------------------------------
    private void SeedSampleData()
    {
        var general  = AddDepartment("General Medicine",  "Ground Floor, Wing A");
        var peds     = AddDepartment("Pediatrics",        "Second Floor, Wing B");
        var internalMed = AddDepartment("Internal Medicine", "Second Floor, Wing A");

        var santos   = AddDoctor("Maria",  "Santos",    "General Medicine",  "09171234567", general);
        var reyes    = AddDoctor("Jose",   "Reyes",     "General Medicine",  "09181234567", general);
        var delacruz = AddDoctor("Ana",    "Dela Cruz", "Pediatrics",        "09191234567", peds);
        var bautista = AddDoctor("Ramon",  "Bautista",  "Internal Medicine", "09201234567", internalMed);
        AddDoctor("Liza", "Mendoza", "Pediatrics", "09211234567", peds);

        var juan    = AddPatient("Juan",    "Dela Cruz",  new DateTime(1990, 5, 14),  "Male",   "09221234567", "Purok 3, Apokon, Tagum City");
        var andrea  = AddPatient("Andrea",  "Lim",        new DateTime(1985, 11, 2),  "Female", "09231234567", "Visayan Village, Tagum City");
        var miguel  = AddPatient("Miguel",  "Torres",     new DateTime(2015, 3, 21),  "Male",   "09241234567", "Magugpo East, Tagum City");
        var sofia   = AddPatient("Sofia",   "Garcia",     new DateTime(2018, 7, 9),   "Female", "09251234567", "Mankilam, Tagum City");
        var ricardo = AddPatient("Ricardo", "Villanueva", new DateTime(1972, 1, 30),  "Male",   "09261234567", "Canocotan, Tagum City");

        juan.MedicalRecord.UpdateRecord("O+", "None");
        juan.MedicalRecord.AddEntry("Annual check-up. No chronic conditions found.");

        andrea.MedicalRecord.UpdateRecord("A+", "Penicillin");
        andrea.MedicalRecord.AddEntry("Hypertension diagnosed. Started on medication.");

        miguel.MedicalRecord.UpdateRecord("B+", "Peanuts");
        miguel.MedicalRecord.AddEntry("Routine childhood immunisations completed.");

        sofia.MedicalRecord.UpdateRecord("AB+", "None");
        sofia.MedicalRecord.AddEntry("Mild asthma. Inhaler prescribed as needed.");

        ricardo.MedicalRecord.UpdateRecord("O-", "Sulfa drugs");
        ricardo.MedicalRecord.AddEntry("Type 2 diabetes. Regular monitoring required.");

        var today = DateTime.Today;
        BookAppointment(juan,    santos,   today.AddDays(3), new TimeSpan(9, 0, 0),  "Annual physical examination");
        BookAppointment(andrea,  bautista, today.AddDays(3), new TimeSpan(10, 30, 0), "Blood pressure follow-up");
        BookAppointment(miguel,  delacruz, today.AddDays(4), new TimeSpan(14, 0, 0),  "Childhood vaccination");
        BookAppointment(ricardo, bautista, today.AddDays(5), new TimeSpan(8, 30, 0),  "Diabetes monitoring");

        var past = BookAppointment(juan, reyes, today.AddDays(-14), new TimeSpan(11, 0, 0), "Fever and cough");
        past?.Complete();

        var cancelled = BookAppointment(andrea, santos, today.AddDays(-10), new TimeSpan(13, 0, 0), "Patient rescheduled");
        cancelled?.Cancel();
    }
}
