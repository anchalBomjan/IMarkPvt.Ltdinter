import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/core/services/student.service';

import { ConfirmationService, MessageService } from 'primeng/api';
import { Router } from '@angular/router';
import { StudentDTO } from 'src/app/core/models/student';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html'
})
export class StudentListComponent implements OnInit {
  students: StudentDTO[] = [];
  loading = true;

  constructor(
    private studentService: StudentService,
    private confirmationService: ConfirmationService,
    private messageService: MessageService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getAllStudents().subscribe({
      next: (data) => {
        this.students = data;
        this.loading = false;
      },
      error: () => this.showError('Failed to load students')
    });
  }

  deleteStudent(id: number): void {
    this.confirmationService.confirm({
      message: 'Are you sure you want to delete this student?',
      header: 'Confirm Deletion',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.studentService.deleteStudent(id).subscribe({
          next: () => {
            this.messageService.add({
              severity: 'success',
              summary: 'Success',
              detail: 'Student deleted'
            });
            this.loadStudents();
          },
          error: () => this.showError('Failed to delete student')
        });
      }
    });
  }

  private showError(detail: string): void {
    this.messageService.add({
      severity: 'error',
      summary: 'Error',
      detail
    });
  }
}