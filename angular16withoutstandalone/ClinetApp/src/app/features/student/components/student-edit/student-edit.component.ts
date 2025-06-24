
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/student.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.scss'],
  providers: [MessageService]  // Optional if already added in app.module.ts
})
export class StudentEditComponent {

  student: Student = { id: 0, name: '', email: '' };

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService,
    private router: Router,
    private messageService: MessageService
  ) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.studentService.getById(id).subscribe(stu => {
      if (stu) {
        // this.student = { ...stu }; // instead of doing this we can do as below 
        this.student.id=stu.id,
        this.student.name=stu.name,
        this.student.email=stu.email
      }
    });
  }

  update(): void {
    this.studentService.update(this.student.id, this.student).subscribe({
      next: () => {
        
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Student updated successfully!',
          life: 3000
        });

        setTimeout(() => {
          this.router.navigate(['/students']);
        }, 1000);
      },
      error: (err) => {
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to update student.',
          life: 3000
        });
        console.error('Update failed:', err);
      }
    });
  }
}
