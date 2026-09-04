# Clinic Appointment System — Analysis & Class Diagram Design

**Tagum City Community Clinic**

---

## 1. Problem Statement (restated)

Tagum City Community Clinic needs a **Clinic Appointment System** to manage
patients, doctors, and appointments. Patients register and schedule
appointments with available doctors. Doctors specialise in medical fields
(General Medicine, Pediatrics, Internal Medicine) and each is assigned to a
department. Patients have medical records containing basic medical information
and history.

---

## 2. Identifying the classes (noun analysis)

The standard technique: extract nouns from the problem statement, then discard
the ones that aren't classes.

| Noun | Class? | Reasoning |
|---|---|---|
| Patient | ✅ **Class** | Has identity, attributes, behaviour |
| Doctor | ✅ **Class** | Has identity, attributes, behaviour |
| Appointment | ✅ **Class** | Has identity + own attributes (date, time, status) |
| Department | ✅ **Class** | Has identity, groups doctors |
| MedicalRecord | ✅ **Class** | Has identity, owned by a patient |
| Clinic | ❌ | System boundary/context, not modelled as a class here |
| Tagum City | ❌ | Location value, not an entity in this scope |
| Specialization | ❌ | An **attribute** of Doctor, not a class |
| Date / time / status | ❌ | **Attributes** of Appointment (rule 10) |
| Staff | ❌ | Mentioned as users, not in the business rules — out of scope |

**Result: 5 classes** — `Patient`, `Doctor`, `Appointment`, `Department`,
`MedicalRecord`.

> **Why Specialization is not a class:** the statement says doctors "specialize
> in different medical fields." Nothing in the business rules gives
> Specialization its own attributes or relationships, so it's an attribute of
> Doctor. Modelling it as a class would be over-engineering and isn't supported
> by the rules.

---

## 3. Relationship analysis — the graded part

This is where marks are won or lost. **Rules 9 and 11 exist specifically to
tell you which relationship type to use.** They are not filler.

### 3.1 The three relationship types you must distinguish

| Type | UML notation | Meaning | Lifecycle |
|---|---|---|---|
| **Association** | plain line | "uses" / "is related to" | Independent |
| **Aggregation** | **hollow/white diamond** ◇ | "has-a", shared | Part **survives** the whole |
| **Composition** | **filled/black diamond** ◆ | "owns", exclusive | Part **dies with** the whole |

The diamond always sits **on the side of the whole/container**.

### 3.2 Applying the rules

#### Patient ↔ Appointment (rules 1, 2)

- Rule 1: "A Patient can schedule **zero or many** Appointments" → `0..*`
- Rule 2: "Each Appointment is for **one** Patient" → `1`

**Type: Association**, multiplicity `1 ──── 0..*`

Why not composition? An Appointment has its own identity and meaning — it is
scheduled, completed, cancelled. It is not an inseparable part of the Patient.

#### Doctor ↔ Appointment (rules 3, 4)

- Rule 3: "A Doctor can handle **zero or many** Appointments" → `0..*`
- Rule 4: "Each Appointment is handled by **one** Doctor" → `1`

**Type: Association**, multiplicity `1 ──── 0..*`

#### Department ↔ Doctor (rules 5, 6, 11)

- Rule 5: "A Department can have **many** Doctors" → `1..*` (or `0..*`)
- Rule 6: "Each Doctor belongs to **one** Department" → `1`

**Type: AGGREGATION (hollow diamond ◇ on Department)**

> 🔑 **Rule 11 is the instruction.** *"The clinic has several doctors and
> departments that operate **independently** of individual appointments."*
>
> The word **independently** signals aggregation. A Doctor is *part of* a
> Department, but if the Pediatrics department were dissolved, **Dr. Santos
> does not cease to exist** — she'd be reassigned. The part outlives the whole.
> That is precisely aggregation, not composition.

#### Patient ↔ MedicalRecord (rules 7, 8, 9)

- Rule 7: "A Patient has **one** MedicalRecord" → `1`
- Rule 8: "Each MedicalRecord belongs to **one** Patient" → `1`

**Type: COMPOSITION (filled diamond ◆ on Patient)**

> 🔑 **Rule 9 is the instruction.** *"A MedicalRecord is considered part of the
> patient's clinic record and **does not exist independently** in this system."*
>
> "Does not exist independently" is the textbook definition of composition.
> Delete the Patient → the MedicalRecord is deleted with them. The part cannot
> outlive the whole. Exclusive ownership.

### 3.3 Summary table

| # | Relationship | Type | Multiplicity | Justifying rule |
|---|---|---|---|---|
| 1 | Patient — Appointment | Association | `1` → `0..*` | Rules 1, 2 |
| 2 | Doctor — Appointment | Association | `1` → `0..*` | Rules 3, 4 |
| 3 | Department ◇— Doctor | **Aggregation** | `1` → `1..*` | Rules 5, 6, **11** |
| 4 | Patient ◆— MedicalRecord | **Composition** | `1` → `1` | Rules 7, 8, **9** |

### 3.4 The contrast that earns the marks

Put rules 9 and 11 side by side — they are deliberately opposite:

| | MedicalRecord | Doctor |
|---|---|---|
| Rule wording | "does **not** exist independently" | "operate **independently**" |
| Whole | Patient | Department |
| Delete the whole → | Part is **destroyed** | Part **survives**, gets reassigned |
| Diamond | ◆ **Filled** (composition) | ◇ **Hollow** (aggregation) |

**If your diagram uses the same relationship type for both, you have missed the
entire point of rules 9 and 11.** State this contrast explicitly in your
submission — it demonstrates you understood *why*, not just *what*.

---

## 4. Multiplicity notation reference

| Notation | Meaning |
|---|---|
| `1` | Exactly one (mandatory) |
| `0..1` | Zero or one (optional) |
| `0..*` or `*` | Zero or many |
| `1..*` | One or many (at least one) |
| `n..m` | Between n and m |

**Reading a multiplicity:** it is placed at the **far end** from the class it
describes. `Patient 1 ──── 0..* Appointment` reads as: *one Patient relates to
zero-or-many Appointments*, and *each Appointment relates to exactly one
Patient*.

> **Rule 5 note:** "A Department can have **many** Doctors." Strictly, "many"
> could be `1..*` or `0..*`. I've used **`1..*`** — a department with no doctors
> is not meaningful for this clinic. If your instructor prefers `0..*` (allowing
> a newly created empty department), that's equally defensible — **just be
> ready to justify whichever you choose.**

---

## 5. Attributes and methods

Attributes are drawn from the statement; only rule 10 mandates specific ones
(`date`, `time`, `status` on Appointment). The rest are reasonable inferences
and should be flagged as such.

### Patient
```
- patientId      : int
- firstName      : string
- lastName       : string
- dateOfBirth    : Date
- gender         : string
- contactNumber  : string
- address        : string
--------------------------------
+ scheduleAppointment(...)
+ cancelAppointment(...)
+ viewMedicalRecord()
+ getFullName() : string
```

### Doctor
```
- doctorId       : int
- firstName      : string
- lastName       : string
- specialization : string     ← "General Medicine", "Pediatrics", "Internal Medicine"
- contactNumber  : string
--------------------------------
+ viewSchedule()
+ handleAppointment(...)
+ getFullName() : string
```

### Appointment
```
- appointmentId  : int
- date           : Date       ← rule 10
- time           : Time       ← rule 10
- status         : Status     ← rule 10 (Scheduled/Completed/Cancelled/NoShow)
- reason         : string
--------------------------------
+ schedule()
+ cancel()
+ complete()
+ reschedule(...)
```

### Department
```
- departmentId   : int
- name           : string     ← "Pediatrics", "Internal Medicine"
- location       : string
--------------------------------
+ addDoctor(...)
+ removeDoctor(...)
+ listDoctors()
```

### MedicalRecord
```
- recordId       : int
- bloodType      : string
- allergies      : string
- medicalHistory : string
- lastUpdated    : Date
--------------------------------
+ addEntry(...)
+ updateRecord(...)
+ viewHistory()
```

> **`status` as an enumeration:** rule 10 requires a status. Modelling it as an
> `«enumeration» AppointmentStatus` (Scheduled, Completed, Cancelled, NoShow) is
> stronger than a free-text string — it makes invalid states unrepresentable.
> Shown in the diagram as a stereotyped box.

---

## 6. Common mistakes to avoid

| Mistake | Why it costs marks |
|---|---|
| Using association for MedicalRecord | Ignores rule 9's "does not exist independently" |
| Using composition for Doctor–Department | Contradicts rule 11's "operate independently" |
| Putting the diamond on the wrong end | The diamond goes on the **whole**, not the part |
| Making Specialization a class | Over-modelling; unsupported by the rules |
| Omitting multiplicities | They're explicitly given in rules 1–8 |
| Drawing arrows on associations | Plain associations are undirected unless navigability is intended |
| Adding foreign-key attributes like `patientId` inside Appointment | That's a *database* concept. In a class diagram the **relationship line** expresses it |

> The last one is subtle and very common. In UML you do **not** put
> `patientId : int` inside `Appointment` — the association line already says
> that. Foreign keys belong in the ERD/SQL, not the class diagram. (The C#
> reference implementation uses object references, which is the correct OOP
> equivalent.)

---

## 7. Note on "UMLA"

The activity sheet says *"UMLA class diagram"*. There is no modelling standard
called UMLA — this is a typo for **UML** (Unified Modeling Language). This
deliverable is a **UML Class Diagram**. Worth a quiet confirmation with your
instructor, but no ambiguity about what's required.
