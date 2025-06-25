import { Component } from '@angular/core';
import { IStudent } from 'src/app/core/models/student';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { StudentService } from 'src/app/core/services/Student.Service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss'],
  providers: [MessageService]
})
export class StudentListComponent {
  students: IStudent[] = [];

  showDeleteDialog = false;
  selectedStudentId: number | null = null;

  showCreateDialog = false;
  newStudent: IStudent = {id:0, name: '', email: '', age: 0 };

  constructor(
    private studentService: StudentService,
    private messageService: MessageService,
    private router: Router,
    
  ) {


  console.log('Component loaded');
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getAllStudents().subscribe(data => {
      this.students = data;
    });
  }

  openDeleteDialog(id: number) {
    this.selectedStudentId = id;
    this.showDeleteDialog = true;
  }

  confirmDelete() {
    if (this.selectedStudentId !== null) {
      this.studentService.deleteStudent(this.selectedStudentId).subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Deleted',
          detail: 'Student deleted successfully'
        });
        this.showDeleteDialog = false;
        this.selectedStudentId = null;
        this.loadStudents();
      });
    }
  }

  cancelDelete() {
    this.showDeleteDialog = false;
    this.selectedStudentId = null;
  }

  openCreateDialog() {
    this.newStudent = { name: '', email: '', age: 0 };
    this.showCreateDialog = true;
  }

  saveStudent() {
    this.studentService.addStudent(this.newStudent).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Created',
        detail: 'Student added successfully'
      });
      this.showCreateDialog = false;
      this.loadStudents();
    });
  }

  editStudent(id: number) {
    this.router.navigate(['/students/edit', id]);
  }
}
