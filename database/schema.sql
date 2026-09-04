-- =====================================================================
--  Clinic Appointment System — Tagum City Community Clinic
--  MySQL 8.0 schema derived from the UML class diagram
--
--  HOW THE UML RELATIONSHIPS MAP TO SQL:
--    Composition (Rule 9)  -> FOREIGN KEY ... ON DELETE CASCADE
--                             (the part is destroyed with the whole)
--    Aggregation (Rule 11) -> FOREIGN KEY ... ON DELETE SET NULL
--                             (the part survives, merely unassigned)
--    Association           -> FOREIGN KEY ... ON DELETE RESTRICT
--
--  This mapping is the practical proof that aggregation and composition
--  are genuinely different — they produce different delete behaviour.
-- =====================================================================

DROP DATABASE IF EXISTS ClinicAppointmentSystem;
CREATE DATABASE ClinicAppointmentSystem
    CHARACTER SET utf8mb4
    COLLATE utf8mb4_0900_ai_ci;

USE ClinicAppointmentSystem;


-- ---------------------------------------------------------------------
-- Department
-- ---------------------------------------------------------------------
CREATE TABLE Department (
    DepartmentID    INT             NOT NULL AUTO_INCREMENT,
    Name            VARCHAR(100)    NOT NULL,
    Location        VARCHAR(255),

    CONSTRAINT pk_department PRIMARY KEY (DepartmentID),
    CONSTRAINT uq_department_name UNIQUE (Name)
) ENGINE = InnoDB;


-- ---------------------------------------------------------------------
-- Doctor
--   Rule 6  : each doctor belongs to one department
--   Rule 11 : AGGREGATION — doctors operate independently.
--
--   DepartmentID is NULLABLE and uses ON DELETE SET NULL. Deleting a
--   department does NOT delete its doctors; they survive, unassigned,
--   ready to be reassigned. This is aggregation expressed in SQL.
-- ---------------------------------------------------------------------
CREATE TABLE Doctor (
    DoctorID        INT             NOT NULL AUTO_INCREMENT,
    FirstName       VARCHAR(50)     NOT NULL,
    LastName        VARCHAR(50)     NOT NULL,
    Specialization  VARCHAR(100)    NOT NULL,
    ContactNumber   VARCHAR(15),
    DepartmentID    INT             NULL,          -- nullable: see Rule 11

    CONSTRAINT pk_doctor PRIMARY KEY (DoctorID),
    CONSTRAINT fk_doctor_department
        FOREIGN KEY (DepartmentID)
        REFERENCES Department (DepartmentID)
        ON DELETE SET NULL                          -- AGGREGATION
        ON UPDATE CASCADE
) ENGINE = InnoDB;

CREATE INDEX idx_doctor_department     ON Doctor (DepartmentID);
CREATE INDEX idx_doctor_specialization ON Doctor (Specialization);


-- ---------------------------------------------------------------------
-- Patient
-- ---------------------------------------------------------------------
CREATE TABLE Patient (
    PatientID       INT             NOT NULL AUTO_INCREMENT,
    FirstName       VARCHAR(50)     NOT NULL,
    LastName        VARCHAR(50)     NOT NULL,
    DateOfBirth     DATE,
    Gender          VARCHAR(20),
    ContactNumber   VARCHAR(15),
    Address         VARCHAR(255),

    CONSTRAINT pk_patient PRIMARY KEY (PatientID)
) ENGINE = InnoDB;

CREATE INDEX idx_patient_lastname ON Patient (LastName);


-- ---------------------------------------------------------------------
-- MedicalRecord
--   Rules 7, 8 : exactly one per patient  -> UNIQUE on PatientID (1:1)
--   Rule 9     : COMPOSITION — does not exist independently.
--
--   PatientID is NOT NULL and uses ON DELETE CASCADE. Delete the patient
--   and the record is destroyed with them. This is composition in SQL.
-- ---------------------------------------------------------------------
CREATE TABLE MedicalRecord (
    RecordID        INT             NOT NULL AUTO_INCREMENT,
    PatientID       INT             NOT NULL,       -- mandatory: see Rule 9
    BloodType       VARCHAR(5),
    Allergies       TEXT,
    MedicalHistory  TEXT,
    LastUpdated     DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP
                                    ON UPDATE CURRENT_TIMESTAMP,

    CONSTRAINT pk_medicalrecord PRIMARY KEY (RecordID),

    -- enforces the 1:1 multiplicity of Rules 7 and 8
    CONSTRAINT uq_medicalrecord_patient UNIQUE (PatientID),

    CONSTRAINT fk_medicalrecord_patient
        FOREIGN KEY (PatientID)
        REFERENCES Patient (PatientID)
        ON DELETE CASCADE                           -- COMPOSITION
        ON UPDATE CASCADE
) ENGINE = InnoDB;


-- ---------------------------------------------------------------------
-- Appointment
--   Rules 1, 2 : one patient, zero-or-many appointments
--   Rules 3, 4 : one doctor,  zero-or-many appointments
--   Rule 10    : records date, time and status
--
--   Both FKs are ON DELETE RESTRICT: appointments are historical records
--   and must not silently disappear. Plain associations.
-- ---------------------------------------------------------------------
CREATE TABLE Appointment (
    AppointmentID   INT             NOT NULL AUTO_INCREMENT,
    PatientID       INT             NOT NULL,       -- Rule 2: exactly one
    DoctorID        INT             NOT NULL,       -- Rule 4: exactly one
    AppointmentDate DATE            NOT NULL,       -- Rule 10
    AppointmentTime TIME            NOT NULL,       -- Rule 10
    Status          ENUM('Scheduled', 'Completed', 'Cancelled', 'NoShow')
                                    NOT NULL DEFAULT 'Scheduled',   -- Rule 10
    Reason          VARCHAR(255),

    CONSTRAINT pk_appointment PRIMARY KEY (AppointmentID),

    CONSTRAINT fk_appointment_patient
        FOREIGN KEY (PatientID)
        REFERENCES Patient (PatientID)
        ON DELETE RESTRICT                          -- ASSOCIATION
        ON UPDATE CASCADE,

    CONSTRAINT fk_appointment_doctor
        FOREIGN KEY (DoctorID)
        REFERENCES Doctor (DoctorID)
        ON DELETE RESTRICT                          -- ASSOCIATION
        ON UPDATE CASCADE,

    -- a doctor cannot be double-booked for the same date and time
    CONSTRAINT uq_doctor_slot UNIQUE (DoctorID, AppointmentDate, AppointmentTime)
) ENGINE = InnoDB;

CREATE INDEX idx_appointment_patient ON Appointment (PatientID);
CREATE INDEX idx_appointment_doctor  ON Appointment (DoctorID);
CREATE INDEX idx_appointment_date    ON Appointment (AppointmentDate);
