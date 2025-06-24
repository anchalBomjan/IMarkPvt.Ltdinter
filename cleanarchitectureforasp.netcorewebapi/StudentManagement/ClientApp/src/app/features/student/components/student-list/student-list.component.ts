import { Component } from '@angular/core';
import { StudentService } from 'src/app/core/services/student.service';
import { IStudent } from 'src/app/core/models/student';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

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
  newStudent: IStudent = { Name: '', Email: '', Age: 0 };

  constructor(
    private studentService: StudentService,
    private messageService: MessageService,
    private router: Router,
    private http:HttpClient
  ) {
    this.http.get('https://localhost:44330/api/Student').subscribe({
    next: res => console.log('API working', res),
    error: err => console.error('API failed', err)
    
  });
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
    this.newStudent = { Name: '', Email: '', Age: 0 };
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
