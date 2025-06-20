import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentService } from 'src/app/core/services/student.service';
import { MessageService } from 'primeng/api';
import { StudentDTO } from 'src/app/core/models/student';

@Component({
  selector: 'app-student-details',
  templateUrl: './student-details.component.html'
})
export class StudentDetailsComponent implements OnInit {
  student: StudentDTO | null = null;
  loading = true;

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService,
    private messageService: MessageService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.params['id'];
    if (id) {
      this.loadStudent(+id);
    }
  }

  goBack(): void {
    history.back(); // <-- This is fine in TypeScript
  }
  

  loadStudent(id: number): void {
    this.studentService.getStudentById(id).subscribe({
      next: (student) => {
        this.student = student;
        this.loading = false;
      },
      error: () => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to load student details'
        });
        this.loading = false;
      }
    });


  }
}