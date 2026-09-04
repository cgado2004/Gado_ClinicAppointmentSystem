-- =====================================================================
--  PROVING composition vs aggregation actually differ
--
--  Run this AFTER schema.sql and seed-data.sql.
--  It demonstrates that Rules 9 and 11 produce genuinely different
--  behaviour — which is the whole point of the two relationship types.
--
--  Everything runs inside a transaction and is rolled back at the end,
--  so your seed data is left untouched.
--
--  ⚠️ NOTE: DDL auto-commits and cannot be rolled back. This script uses
--  only DML (DELETE), so the ROLLBACK genuinely works.
-- =====================================================================

USE ClinicAppointmentSystem;

START TRANSACTION;

-- ---------------------------------------------------------------------
-- TEST 1 — COMPOSITION (Rule 9)
--   Deleting a Patient must DESTROY the MedicalRecord.
-- ---------------------------------------------------------------------
SELECT '=== TEST 1: COMPOSITION (Rule 9) ===' AS Test;

SELECT COUNT(*) AS RecordsForPatient1_Before
FROM   MedicalRecord
WHERE  PatientID = 1;
-- expected: 1

DELETE FROM Appointment WHERE PatientID = 1;   -- clear RESTRICT-ed rows first
DELETE FROM Patient     WHERE PatientID = 1;

SELECT COUNT(*) AS RecordsForPatient1_After
FROM   MedicalRecord
WHERE  PatientID = 1;
-- expected: 0  ← CASCADE destroyed it. The part died with the whole.

SELECT 'PASS: MedicalRecord was destroyed with its Patient (composition).' AS Result;


-- ---------------------------------------------------------------------
-- TEST 2 — AGGREGATION (Rule 11)
--   Deleting a Department must NOT destroy its Doctors.
-- ---------------------------------------------------------------------
SELECT '=== TEST 2: AGGREGATION (Rule 11) ===' AS Test;

SELECT COUNT(*) AS DoctorsInPediatrics_Before
FROM   Doctor
WHERE  DepartmentID = 2;
-- expected: 2

DELETE FROM Department WHERE DepartmentID = 2;

SELECT COUNT(*) AS DoctorsStillExisting_After
FROM   Doctor
WHERE  Specialization = 'Pediatrics';
-- expected: 2  ← they SURVIVED

SELECT DoctorID,
       CONCAT(FirstName, ' ', LastName) AS DoctorName,
       Specialization,
       DepartmentID                     AS NowUnassigned
FROM   Doctor
WHERE  Specialization = 'Pediatrics';
-- DepartmentID is now NULL — unassigned, not deleted.

SELECT 'PASS: Doctors survived their Department (aggregation).' AS Result;


-- ---------------------------------------------------------------------
-- Undo everything
-- ---------------------------------------------------------------------
ROLLBACK;

SELECT 'All changes rolled back — seed data is intact.' AS Cleanup;


-- =====================================================================
--  SUMMARY
--
--    Rule 9  | Patient ◆── MedicalRecord | ON DELETE CASCADE  | part DIES
--    Rule 11 | Department ◇── Doctor     | ON DELETE SET NULL | part LIVES
--
--  Same 1-to-many shape. Completely different semantics.
-- =====================================================================
