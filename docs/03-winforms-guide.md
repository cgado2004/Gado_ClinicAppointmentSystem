# WinForms UI — Guide & Demo Script

## Opening it in Visual Studio 2022

1. **File → Open → Project/Solution**
2. Select **`ClinicAppointmentSystem.sln`** (the solution, not a folder)
3. In Solution Explorer, right-click **ClinicAppointmentSystem.WinForms** →
   **Set as Startup Project**
4. Press **F5**

> If the Designer won't open a form: **Build → Build Solution** first. The
> designer needs a compiled assembly to render controls. This is the single
> most common WinForms annoyance.

**Required workload:** ".NET desktop development". If the project won't load,
open Visual Studio Installer → Modify → tick it.

---

## Architecture

```
┌──────────────────────────────────────────┐
│  ClinicAppointmentSystem.WinForms        │   ← UI layer
│    Program.cs      entry + message loop  │
│    Forms/          MainForm + 5 dialogs  │
│    Data/           ClinicRepository      │
└──────────────────┬───────────────────────┘
                   │  project reference (one direction only)
                   ▼
┌──────────────────────────────────────────┐
│  ClinicAppointmentSystem.Domain          │   ← the class diagram, in code
│    Entities/  Patient, Doctor, …         │
│    Enums/     AppointmentStatus          │
└──────────────────────────────────────────┘
```

**The Domain project has no reference to WinForms.** That's deliberate and it's
the same lesson as `microsoft/calculator`: the engine is separate from the UI.
Consequences worth stating in a write-up:

- Business rules can be unit-tested without opening a window
- The UI could be swapped for a web app with zero domain changes
- `ClinicRepository` could be swapped for MySQL with zero *form* changes

---

## The forms

| Form | Purpose | Notable controls |
|---|---|---|
| **MainForm** | Four-tab shell | `TabControl`, 4× `DataGridView`, `StatusStrip`, `SplitContainer` |
| **PatientForm** | Register a patient | `TextBox`, `DateTimePicker`, `GroupBox` + `RadioButton` |
| **DoctorForm** | Add a doctor | `ComboBox` (editable + list), department picker with "(none)" |
| **AppointmentForm** | Book an appointment | `ComboBox`, `DateTimePicker`, live availability check |
| **MedicalRecordForm** | View/edit a record | Read-only history `TextBox`, append-entry pattern |
| **DepartmentForm** | Add a department | Simple two-field dialog |

---

## Demo script — proving you understood Rules 9 and 11

If you have to present this, run these two demos back to back. They're the
whole point of the activity.

### Demo A — Composition (Rule 9)

1. **Patients** tab → select **Juan Dela Cruz**
2. Click **View Medical Record** → note it exists, record #1, blood type O+
3. Close, click **Delete Patient**
4. Read the confirmation dialog aloud — it names the record being destroyed
5. Confirm

> **Say this:** "The medical record was destroyed with the patient. Rule 9 says
> it does not exist independently. In code, `MedicalRecord`'s constructor is
> `internal` and takes a required `Patient` — I *cannot* create an orphan
> record. In SQL it's `ON DELETE CASCADE`."

### Demo B — Aggregation (Rule 11)

1. **Departments** tab → select **Pediatrics** → note 2 doctors listed
2. Click **Remove Department (Rule 11 demo)**
3. Read the dialog — it says the doctors will survive
4. Confirm. The app jumps to the **Doctors** tab automatically
5. Point at Dela Cruz and Mendoza, now showing **"(unassigned)"**

> **Say this:** "The doctors survived. Rule 11 says they operate independently.
> Dissolving a department doesn't end anyone's employment — they're reassigned.
> In code, `Doctor` has a public constructor and a nullable `Department`. In
> SQL it's `ON DELETE SET NULL`."

**The contrast is the answer.** Same 1-to-many shape, opposite semantics,
because rules 9 and 11 use opposite language.

---

## Techniques demonstrated

Useful if you're asked "why did you do it this way?"

### State lives in fields, not locals

```csharp
public partial class MainForm : Form
{
    private readonly ClinicRepository _repository = new();   // FIELD
```

Each click is a separate event and each handler returns immediately. A local
variable would be destroyed before the next click. Same reason `num1` and
`operation` must be fields in the calculator exercise.

### TryParse, never Parse

```csharp
if (!TimeSpan.TryParse(cmbTime.Text, out TimeSpan time))
{
    MessageBox.Show("The selected time is not valid.");
    return;
}
```

`Parse` throws on bad input and crashes the app. `TryParse` returns `false`.

### Blocking bad input at the keystroke

```csharp
private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar is not ('+' or '-' or ' '))
        e.Handled = true;      // swallow it
}
```

### RadioButtons scoped by container

The status filter radios are inside a `GroupBox`, and the gender radios are
inside a different one. **Radio grouping is by container, not by name** — six
radios directly on a form would all be mutually exclusive.

### CheckedChanged fires twice

```csharp
private void StatusFilter_CheckedChanged(object sender, EventArgs e)
{
    if (sender is RadioButton { Checked: true })   // ignore the switch-OFF
        RefreshAppointments();
}
```

Changing a radio selection raises the event twice — once for the control turning
off, once for the one turning on. Without the guard you refresh twice.

### Catching domain exceptions instead of crashing

```csharp
try
{
    action(appointment);          // may throw InvalidOperationException
}
catch (InvalidOperationException ex)
{
    MessageBox.Show(ex.Message, "Invalid operation");
}
```

`Appointment.Complete()` refuses to run on a cancelled appointment. The domain
enforces the rule; the UI reports it. **Try it:** cancel an appointment, then
press "Mark Completed".

### Dialogs return data through properties

```csharp
using var dialog = new PatientForm();
if (dialog.ShowDialog(this) != DialogResult.OK) return;
var patient = _repository.AddPatient(dialog.FirstName, dialog.LastName, …);
```

`using` disposes the form. The caller reads typed properties, not raw controls.

### Validation keeps the dialog open

`btnSave` has `DialogResult.None`, so failing validation simply returns and the
window stays put. Setting `DialogResult.OK` in the designer would close the
dialog before validation could run — a subtle and common bug.

---

## Swapping the in-memory store for MySQL

`ClinicRepository` is the only class that knows where data lives. To move to
the real database:

1. Add the NuGet package `MySql.Data`
2. Extract an interface `IClinicRepository` from the current class
3. Write `MySqlClinicRepository : IClinicRepository` using `database/schema.sql`
4. Change one line in `MainForm`

No form changes. That's what the layering buys you.

---

## Troubleshooting

| Problem | Cause / fix |
|---|---|
| Designer won't open | Build the solution first |
| "does not contain a static 'Main'" | Wrong startup project — set the WinForms one |
| Blurry on a 4K display | `ApplicationHighDpiMode` is set to `PerMonitorV2`; make sure you're on .NET 8 |
| Changes not appearing | Stale build: **Build → Clean Solution**, then rebuild |
| `bin/`+`obj/` in Git | `.gitignore` covers them; if already committed, `git rm -r --cached bin obj` |
| Grid shows object type names | Bind to an anonymous projection, not the entity — see the `Refresh*` methods |
