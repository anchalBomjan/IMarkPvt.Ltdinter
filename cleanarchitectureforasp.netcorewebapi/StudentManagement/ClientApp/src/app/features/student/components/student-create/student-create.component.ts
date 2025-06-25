// import { Component } from '@angular/core';
// import { Router } from '@angular/router';
// import { MessageService } from 'primeng/api';
// import { IStudent } from 'src/app/core/models/student';
// import { StudentService } from 'src/app/core/services/Student.Service';

// @Component({
//   selector: 'app-student-create',
//   templateUrl: './student-create.component.html',
//   styleUrls: ['./student-create.component.scss']
// })
// export class StudentCreateComponent {
//    students:IStudent[]=[];
//    showDeleteDialog=false;
//    showCreateDialog = false;
//   newStudent: IStudent = {id:0, name: '', email: '', age: 0 };

//    constructor(private studentService:StudentService,private messageService:MessageService,private router:Router)
//    {
//     this.loadStudents();


//    }
//    loadStudents(): void {
//     this.studentService.getAllStudents().subscribe(data => {
//       this.students = data;

//       console.log('Student loaded',data);
//     });
//   }

//    saveStudent()
//    { 
//     console.log('Saving Student:', this.newStudent);// Log the student data veing sent
//     this.studentService.addStudent(this.newStudent).subscribe({
   
//       next:(response)=>{
//         console.log('Student saved successfully:',response);
//         this.messageService.add({
//           severity:'success',
//           summary:'success',
//           detail:'Student added successfully'

//         });

//         this.showCreateDialog=false;
//         this.loadStudents();
//       },
//       error:(error)=>{
//       console.log('Error saving student',error);
//       }
//     });

//    }
// }

import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IStudent } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/Student.Service';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.scss']
})
export class StudentCreateComponent {
  @Input() showCreateDialog: boolean = false;
  @Output() closeDialog = new EventEmitter<void>();
  @Output() studentSaved = new EventEmitter<void>();

  newStudent: IStudent = { id: 0, name: '', email: '', age: 0 };


  constructor(
    private studentService: StudentService,
    private messageService: MessageService
  ) {
    this.loadStudents();
  }
  loadStudents(): void {
    this.studentService.getAllStudents().subscribe(data => {

      console.log('Student loaded',data);
    });
  }


  
openCreateDialog() {
    this.newStudent = { name: '', email: '', age: 0 };
    this.showCreateDialog = true;
  }
  saveStudent() {
    console.log('Saving Student:', this.newStudent);
    this.studentService.addStudent(this.newStudent).subscribe({
      next: (response) => {
        console.log('Student saved successfully:', response);
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Student added successfully'
        });
        this.studentSaved.emit();  // Notify parent to reload student list
        this.closeDialog.emit();
        this.showCreateDialog=false;
      
        this.loadStudents();
        
      },
      error: (error) => {
        console.log('Error saving student', error);
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to save student'
        });
      }
    });
  }
  onCancel() {
    this.closeDialog.emit(); // notifies parent to close the dialog
    this.resetForm();        // resets form values (optional and recommended)
  }
  
  private resetForm() {
    this.newStudent = { id: 0, name: '', email: '', age: 0 };
  }
  
 
}
