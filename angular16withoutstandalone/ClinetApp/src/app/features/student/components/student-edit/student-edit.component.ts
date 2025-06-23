import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Student } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/student.service';

@Component({
  selector: 'app-student-edit',
  templateUrl: './student-edit.component.html',
  styleUrls: ['./student-edit.component.scss']
})
export class StudentEditComponent {


  student: Student = { id: 0, name: '', email: '' };

  constructor(
    private route: ActivatedRoute,
    private studentService: StudentService,
    private router: Router
  ) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.studentService.getById(id).subscribe(stu => {
      //instead of using three dot
      //if (stu) this.student = { ...stu };
      if(stu){
        this.student.id=stu.id;
        this.student.email=stu.email;
        this.student.name=stu.name;
      }
    });
  }

 // update(): void {
  //  this.studentService.update(this.student.id, this.student).subscribe(() => {
  //    this.router.navigate(['/students']);
  //  });
  update(): void {
    console.log('Update method called for:', this.student);
    this.studentService.update(this.student.id, this.student).subscribe({
      next: () => {
        console.log('Update successful, navigating now...');
        this.router.navigate(['/students']);
      },
      error: (err) => {
        console.error('Update failed:', err);
      }
    });
  }
  
  }

