# Publishing this to GitHub from Visual Studio 2022

Two routes. **Route A is easiest** and is what VS 2022 is built for.

---

## Before you start

1. **A GitHub account** — [github.com/join](https://github.com/join)
2. **Git installed.** VS 2022 bundles it. Check in a terminal:
   ```
   git --version
   ```
   If missing: [git-scm.com/downloads](https://git-scm.com/downloads)
3. **Visual Studio 2022** with the **".NET desktop development"** workload
   (needed for WinForms; the Git tooling is included by default).

---

## Route A — Straight from Visual Studio (recommended)

### 1. Sign in to GitHub inside VS

`File → Account Settings… → Add an account → GitHub`

Sign in through the browser window that opens. VS stores the credentials, so
you won't be asked again.

### 2. Open the folder

`File → Open → Folder…` → select `ClinicAppointmentSystem`

(Or open `src/ClinicAppointmentSystem.Domain/ClinicAppointmentSystem.Domain.csproj`
if you only want the C# project.)

### 3. Create the Git repository

`Git → Create Git Repository…`

In the dialog:

| Field | Value |
|---|---|
| **Push to** | GitHub |
| **Account** | your GitHub account |
| **Owner** | your username |
| **Repository name** | `ClinicAppointmentSystem` |
| **Description** | UML class diagram and domain model for a clinic appointment system |
| **Private repository** | ✅ **tick this** — see the warning below |
| **.gitignore template** | *None* — this repo already has one |
| **License** | None (or MIT if you want) |

Click **Create and Push**. Done — VS initialises the repo, commits everything,
creates it on GitHub, and pushes.

> ⚠️ **Tick "Private" for coursework.** A public repo containing a graded
> assignment can be found by classmates and by plagiarism checkers. If someone
> copies your public repo, *you* may be caught up in the investigation. Make it
> public after the module ends if you want it in a portfolio.

### 4. Everyday workflow after that

`View → Git Changes` (or **Ctrl+0, Ctrl+G**)

1. Type a commit message
2. **Commit All**
3. **Push** (the ↑ arrow)

---

## Route B — Command line

Run these from inside the `ClinicAppointmentSystem` folder.

### One-time Git identity

```bash
git config --global user.name  "Your Name"
git config --global user.email "you@example.com"
```

Use the same email as your GitHub account or commits won't be linked to you.

### Initialise and commit

```bash
cd ClinicAppointmentSystem

git init
git branch -M main
git add .
git commit -m "Add UML class diagram and domain model for Clinic Appointment System"
```

### Create the repo on GitHub

Go to [github.com/new](https://github.com/new):

- **Name:** `ClinicAppointmentSystem`
- **Visibility:** **Private**
- **Do NOT** tick "Add a README", ".gitignore", or "license" — this repo has
  them already, and adding them creates a conflict on your first push.

### Push

```bash
git remote add origin https://github.com/YOUR-USERNAME/ClinicAppointmentSystem.git
git push -u origin main
```

You'll be prompted to authenticate. GitHub **does not accept passwords** —
use one of:
- **Git Credential Manager** (installed with VS/Git) — opens a browser, easiest
- **Personal Access Token** — Settings → Developer settings → Personal access
  tokens → Tokens (classic) → Generate, with the `repo` scope. Paste the token
  where it asks for a password.

---

## Verifying it worked

Open `https://github.com/YOUR-USERNAME/ClinicAppointmentSystem`. You should see:

- ✅ The README rendered, **with the Mermaid class diagram drawn as a picture**
- ✅ `docs/`, `diagrams/`, `src/`, `database/`
- ❌ **No `bin/` or `obj/` folders** — if those appear, `.gitignore` isn't working

### If bin/obj got committed anyway

Happens if you committed before adding `.gitignore`:

```bash
git rm -r --cached bin obj
git commit -m "Remove build artefacts from version control"
git push
```

---

## Useful commands

| Command | Does |
|---|---|
| `git status` | What's changed |
| `git add .` | Stage everything |
| `git commit -m "msg"` | Commit staged changes |
| `git push` | Upload to GitHub |
| `git pull` | Download changes |
| `git log --oneline` | Compact history |
| `git diff` | Show unstaged changes |

---

## Commit message convention

Good messages make your history readable — and markers notice.

```
Add MedicalRecord composition relationship
Fix multiplicity on Department-Doctor aggregation
Update class diagram with AppointmentStatus enumeration
```

Present tense, imperative mood, describes *what changed*. Not "update" or
"changes" or "asdf".

---

## Submitting

If your instructor needs the GitHub link:

1. Confirm whether they want it **public** or need to be added as a
   collaborator to a private repo.
2. For a private repo: `Settings → Collaborators → Add people` → their GitHub
   username.
3. For a snapshot: `Code → Download ZIP`, or tag a release:
   ```bash
   git tag -a v1.0 -m "Submission version"
   git push origin v1.0
   ```

---

## Troubleshooting

| Problem | Fix |
|---|---|
| `fatal: not a git repository` | You're in the wrong folder. `cd` into the project |
| `Authentication failed` | Password auth is disabled — use a token or Credential Manager |
| `remote origin already exists` | `git remote set-url origin <new-url>` |
| `Updates were rejected` | You ticked "Add a README" on GitHub. `git pull --rebase origin main`, then push |
| Mermaid diagram not rendering | Fence must be exactly ` ```mermaid ` |
| VS shows no Git menu | `Tools → Options → Environment → Preview Features` → enable the new Git experience |
