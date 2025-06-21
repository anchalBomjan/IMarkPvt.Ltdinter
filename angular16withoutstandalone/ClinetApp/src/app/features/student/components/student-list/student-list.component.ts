import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/student.service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss']
})
export class StudentListComponent {

  students: Student[] = [];

  constructor(private studentService: StudentService, private router: Router)
   {
    this.loadStudents();
   }

  loadStudents(): void {
    this.studentService.getAll().subscribe(data => (this.students = data));
  }
  editStudent(id: number) {
    this.router.navigate(['/students/edit', id]);
  }

  deleteStudent(id: number) {
    this.studentService.delete(id).subscribe(() => this.loadStudents());
  }

}
