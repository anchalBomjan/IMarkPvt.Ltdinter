# ClientApp

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 16.2.12.

## Development server
[Parent] StudentListComponent
└── opens dialog via showCreateDialog = true
└── passes: [student], [mode]
└── listens:, (closeDialog)

[Child] StudentCreateComponent
└── uses [mode] to decide between create/edit
└── uses saveStudent()
└── 
└── emits closeDialog to close the dialog


---# 🏫 Student Management System (Angular + PrimeNG)

This project is a Student Management System built with Angular and PrimeNG. It allows you to:
- View a list of students
- Add a new student using a PrimeNG dialog
- Edit student details via the same dialog
- Delete a student with confirmation
- Perform navigation using Angular Router

---

## 📁 Project Structure

## 🚀 Features

- 🔁 **Reusable dialog** for both `Create` and `Edit` mode (controlled by `[mode]` input).
- 🎯 Two-way communication using `@Input()` and `@Output()`.
- 📥 Parent-Child Component Communication:
  - Parent opens dialog, passes data to child.
  - Child emits `studentSaved` or `closeDialog` to notify parent.
- ✨ PrimeNG for rich UI components like:
  - `p-table` (student list)
  - `p-dialog` (form and delete confirmation)
  - `p-toast` (notification)
  - `p-toolbar` (header actions)

---

## 🧩 Component Communication Flow

