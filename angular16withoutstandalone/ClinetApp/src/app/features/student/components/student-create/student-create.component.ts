import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/student.service';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.scss']
})
export class StudentCreateComponent {
  student: Student = { id: 0, name: '', email: '' };

  constructor(private studentService: StudentService, private router: Router) {}

  save(): void {
    this.studentService.create(this.student).subscribe(() => {
      this.router.navigate(['/students']);
    });
  }
}
