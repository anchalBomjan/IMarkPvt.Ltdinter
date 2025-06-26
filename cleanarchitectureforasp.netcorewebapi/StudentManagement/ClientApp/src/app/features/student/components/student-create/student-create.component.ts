
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { IStudent } from 'src/app/core/models/student';
import { StudentService } from 'src/app/core/services/Student.Service';
import { MessageService } from 'primeng/api';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-student-create',
  templateUrl: './student-create.component.html',
  styleUrls: ['./student-create.component.scss']
})
export class StudentCreateComponent {
  @Input() showCreateDialog: boolean = false;
  @Output() closeDialog = new EventEmitter<void>(); // Emits when the dialog needs to close
  @Output() studentSaved = new EventEmitter<void>();

  newStudent: IStudent = { id: 0, name: '', email: '', age: 0 };

  constructor( private studentService: StudentService,private messageService: MessageService ,private router:Router) 
  {

    this.checkRoute();
    this. loadStudents();

  }


  loadStudents(){
    this.studentService.getAllStudents().subscribe(data=>{
      console.log('student loaded while create/student',data);
    })
  }

  // this  will provided values to open p diaglog box of component.html 
  checkRoute(){
     // Listen to route changes
     this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        if (event.url.includes('/students/create')) {
          this.showCreateDialog = true;
        }
      }
    });

  }

  saveStudent() {
    console.log('Saving Student:', this.newStudent);
    this.studentService.addStudent(this.newStudent).subscribe({
      next: () => {
        this.messageService.add({
          severity: 'success',
          summary: 'Success',
          detail: 'Student added successfully'
        });
        this.studentSaved.emit(); // Notify parent to reload students
       this.closeDialog.emit();  // Close the dialog
       this.resetForm();

        /// this below for create/student
        this.showCreateDialog=false;
       // this.router.navigate(['/students'])

        setTimeout(() => {
          this.router.navigate(['/students']);
        }, 2000);
        
      },
      error: (error) => {
        console.error('Error saving student', error);
        this.messageService.add({
          severity: 'error',
          summary: 'Error',
          detail: 'Failed to save student'
        });
        setTimeout(() => {
          this.router.navigate(['/students']);
        }, 2000);
      }
      
    });
  }



  cancel(){
    this.close();
  }


  private close() {
    this.closeDialog.emit(); // Tells parent to close dialog
    this.resetForm();
    this.router.navigate(['/students']);  //  this extra line helps to work  throught create/student
  }

  private resetForm() {
    this.newStudent = { id: 0, name: '', email: '', age: 0 };
  }
}
