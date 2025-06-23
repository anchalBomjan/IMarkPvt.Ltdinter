// 

import { Component } from '@angular/core';
import { StudentService } from 'src/app/core/services/student.service';
import { Student } from 'src/app/core/models/student';
import { MessageService } from 'primeng/api';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent {
  students: Student[] = [];
  
  showDeleteDialog = false;
  selectedStudentId: number | null = null;

  constructor(
    private studentService: StudentService,
    private router: Router,
    private messageService: MessageService
  ) {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getAll().subscribe(data => (this.students = data));
  }

  editStudent(id: number) {
    this.router.navigate(['/students/edit', id]);
  }

  openDeleteDialog(id: number) {
    this.selectedStudentId = id;
    this.showDeleteDialog = true;
  }

  confirmDelete() {
    if (this.selectedStudentId !== null) {
      this.studentService.delete(this.selectedStudentId).subscribe(() => {
        this.loadStudents();
        this.messageService.add({
          severity: 'success',
          summary: 'Deleted',
          detail: 'Student deleted successfully'
        });
        this.showDeleteDialog = false;
        this.selectedStudentId = null;
      });
    }
  }

  cancelDelete() {
    this.showDeleteDialog = false;
    this.selectedStudentId = null;
  }
}
