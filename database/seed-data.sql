-- =====================================================================
--  Sample data — Tagum City Community Clinic
--  Run schema.sql first.
-- =====================================================================

USE ClinicAppointmentSystem;

-- ---------------------------------------------------------------------
-- Departments
-- ---------------------------------------------------------------------
INSERT INTO Department (Name, Location) VALUES
    ('General Medicine',  'Ground Floor, Wing A'),
    ('Pediatrics',        'Second Floor, Wing B'),
    ('Internal Medicine', 'Second Floor, Wing A');

-- ---------------------------------------------------------------------
-- Doctors
-- ---------------------------------------------------------------------
INSERT INTO Doctor (FirstName, LastName, Specialization, ContactNumber, DepartmentID) VALUES
    ('Maria',   'Santos',    'General Medicine',  '09171234567', 1),
    ('Jose',    'Reyes',     'General Medicine',  '09181234567', 1),
    ('Ana',     'Dela Cruz', 'Pediatrics',        '09191234567', 2),
    ('Ramon',   'Bautista',  'Internal Medicine', '09201234567', 3),
    ('Liza',    'Mendoza',   'Pediatrics',        '09211234567', 2);

-- ---------------------------------------------------------------------
-- Patients
-- ---------------------------------------------------------------------
INSERT INTO Patient (FirstName, LastName, DateOfBirth, Gender, ContactNumber, Address) VALUES
    ('Juan',    'Dela Cruz', '1990-05-14', 'Male',   '09221234567', 'Purok 3, Apokon, Tagum City'),
    ('Andrea',  'Lim',       '1985-11-02', 'Female', '09231234567', 'Visayan Village, Tagum City'),
    ('Miguel',  'Torres',    '2015-03-21', 'Male',   '09241234567', 'Magugpo East, Tagum City'),
    ('Sofia',   'Garcia',    '2018-07-09', 'Female', '09251234567', 'Mankilam, Tagum City'),
    ('Ricardo', 'Villanueva','1972-01-30', 'Male',   '09261234567', 'Canocotan, Tagum City');

-- ---------------------------------------------------------------------
-- Medical records — Rule 9: exactly one per patient, created with them
-- ---------------------------------------------------------------------
INSERT INTO MedicalRecord (PatientID, BloodType, Allergies, MedicalHistory) VALUES
    (1, 'O+',  'None',            'Annual check-up 2025. No chronic conditions.'),
    (2, 'A+',  'Penicillin',      'Hypertension, managed with medication since 2023.'),
    (3, 'B+',  'Peanuts',         'Routine paediatric immunisations complete.'),
    (4, 'AB+', 'None',            'Mild asthma, uses inhaler as needed.'),
    (5, 'O-',  'Sulfa drugs',     'Type 2 diabetes diagnosed 2020. Regular monitoring.');

-- ---------------------------------------------------------------------
-- Appointments — Rule 10: date, time, status
-- ---------------------------------------------------------------------
INSERT INTO Appointment (PatientID, DoctorID, AppointmentDate, AppointmentTime, Status, Reason) VALUES
    (1, 1, '2026-09-08', '09:00:00', 'Scheduled', 'Annual physical examination'),
    (2, 4, '2026-09-08', '10:30:00', 'Scheduled', 'Blood pressure follow-up'),
    (3, 3, '2026-09-09', '14:00:00', 'Scheduled', 'Childhood vaccination'),
    (4, 5, '2026-09-09', '15:00:00', 'Scheduled', 'Asthma review'),
    (5, 4, '2026-09-10', '08:30:00', 'Scheduled', 'Diabetes monitoring'),
    (1, 2, '2026-08-15', '11:00:00', 'Completed', 'Fever and cough'),
    (2, 1, '2026-08-20', '13:00:00', 'Cancelled', 'Patient rescheduled'),
    (3, 3, '2026-08-22', '09:30:00', 'NoShow',    'Missed appointment');
