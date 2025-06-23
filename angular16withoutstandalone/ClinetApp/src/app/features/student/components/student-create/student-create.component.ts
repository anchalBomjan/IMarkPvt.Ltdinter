// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { Student } from 'src/app/core/models/student';
// import { StudentService } from 'src/app/core/services/student.service';

// @Component({
//   selector: 'app-student-create',
//   templateUrl: './student-create.component.html',
//   styleUrls: ['./student-create.component.scss']
// })
// export class StudentCreateComponent {
//   student: Student = { id: 0, name: '', email: '' };

//   constructor(private studentService: StudentService, private router: Router) {}

//   save(): void {
//     this.studentService.create(this.student).subscribe(() => {
//       this.router.navigate(['/students']);
//     });
//   }
// }

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Student } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/student.service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.scss']
})
export class StudentCreateComponent {
  student: Student = { id: 0, name: '', email: '' };
  showDialog = false;

  constructor(
    private studentService: StudentService,
    private router: Router,
    private messageService: MessageService
  ) {}

  openDialog() {
    this.showDialog = true;
  }

  closeDialog() {
    this.showDialog = false;
  }

  save(): void {
    this.studentService.create(this.student).subscribe(() => {
      this.messageService.add({
        severity: 'success',
        summary: 'Success',
        detail: 'Student created successfully!'
      });
      this.closeDialog();
      this.router.navigate(['/students']);
    });
  }
}
