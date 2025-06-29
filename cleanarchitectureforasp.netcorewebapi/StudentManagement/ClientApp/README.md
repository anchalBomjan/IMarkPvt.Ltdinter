# ClientApp💡

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

## 🧩Summary of this projects:📝

✨ Dynamic Create & Edit Form in Angular using p-dialog, NgModel, and FormBuilder
This project demonstrates how to reuse the same form template for both Create and Edit operations using Angular's p-dialog component (from PrimeNG), NgModel, and FormBuilder — all within a modular and dynamic architecture. 🚀
🧩 How it Works
We’ve structured the application to support modular form invocation from a parent component using a shared child form component (CreateComponent).

💡 Core Features
✅ Uses a single form template for both creating and editing data.

🔄 Parent component dynamically passes mode (create or edit) and data (ID) to child.

🧠 Smart condition-based logic inside the form to handle different modes.

📦 Uses Angular’s @Input() and @Output() decorators for dynamic communication between components.

💬 Fully integrated with PrimeNG's p-dialog for a sleek modal interface.

🔄 Flow Overview
Parent Component (e.g. StudentListComponent)

Has two methods: openAddDialog() and openEditDialog(id: number)

Opens the dialog box and dynamically loads CreateComponent via template reference.

Passes mode = 'create' or mode = 'edit' and the corresponding id via @Input().

Child Component (CreateComponent)

Receives:

@Input() showCreateDialog: boolean

@Input() mode: 'create' | 'edit'

@Input() id: number | null

Uses FormBuilder to initialize the form.

If mode is edit, fetches existing student data by ID and populates the form.

Uses NgModel for binding form fields.

Emits:

@Output() closeDialog = new EventEmitter<void>()

@Output() studentSaved = new EventEmitter<any>() after successful create/update.

Automatically closes the dialog and refreshes the parent list on success.

###################ALSO
enabled it to open just by visiting a URL. This is powerful because:

You can share a link like /students/create and it will directly open the form.

It's good for user experience and browser navigation.

You don’t need a parent component to explicitly set showCreateDialog = true. we  trigger throught checkRoute() {
  this.router.events.subscribe(event => {
    if (event instanceof NavigationEnd) {
      if (event.url.includes('/students/create')) {
        this.showCreateDialog = true;
      }
    }
  });
}

