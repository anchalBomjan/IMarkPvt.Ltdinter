
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IStudent } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/Student.Service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.scss']
})
export class StudentCreateComponent {
  @Input() showCreateDialog: boolean = false;
  @Output() closeDialog = new EventEmitter<void>(); // Emits when the dialog needs to close
  @Output() studentSaved = new EventEmitter<void>();

  newStudent: IStudent = { id: 0, name: '', email: '', age: 0 };

  constructor(
    private studentService: StudentService,
    private messageService: MessageService
  ) {}

  saveStudent() {
    console.log('Saving Student:', this.newStudent);
    this.studentService.addStudent(this.newStudent).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Student added successfully'
        });
        this.studentSaved.emit(); // Notify parent to reload students
        this.closeDialog.emit();  // Close the dialog
        this.resetForm();
      },
      error: (error) => {
        console.error('Error saving student', error);
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to save student'
        });
      }
    });
  }

  cancel() {
    this.closeDialog.emit(); // Tells parent to close dialog
    this.resetForm();
  }

  private resetForm() {
    this.newStudent = { id: 0, name: '', email: '', age: 0 };
  }
}
