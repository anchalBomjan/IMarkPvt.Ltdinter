
import { ChangeDetectorRef, Component, EventEmitter, Input, Output } from '@angular/core';
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

  private _student: IStudent = { name: '', email: '', age: 0 };
  @Input()
  set student(value: IStudent) {
    this._student = { ...value };
    this.newStudent = { ...this._student };
    if (this._mode === 'create') {
      this.resetForm();
    }
  }
  get student(): IStudent {
    return this._student;
  }

  private _mode: 'create' | 'edit' = 'create';
  @Input()
  set mode(value: 'create' | 'edit') {
    this._mode = value;
    if (value === 'create') {
      this.resetForm();
    }
  }
  get mode(): 'create' | 'edit' {
    return this._mode;
  }

  @Output() closeDialog = new EventEmitter<void>();
  @Output() studentSaved = new EventEmitter<void>(); // this   helps to notify parentComponent successfuly add so reload list 


  newStudent: IStudent = { name: '', email: '', age: 0 };

  constructor(
    private studentService: StudentService,
    private messageService: MessageService,
    private router: Router,
    
  ) {
    this.checkRoute();
  
  }



  checkRoute() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        if (event.url.includes('/students/create')) {
          this.showCreateDialog = true;
        }
      }
    });
  }

  saveStudent() {
    if (!this.newStudent.name || !this.newStudent.email || this.newStudent.age < 5 || this.newStudent.age > 60) {
      this.messageService.add({
        severity: 'error',
        summary: 'Validation Error',
        detail: 'Please fill out all required fields correctly.'
      });
      return;
    }
    console.log('Saving Student:', this.newStudent);

    if (this.mode=='edit')
    {
      if(this.newStudent.id!==undefined){
        this.studentService.updateStudent(this.newStudent.id!, this.newStudent).subscribe({
          next: () => {
            this.messageService.add({ severity: 'success', summary: 'Updated', detail: 'Student updated successfully' });
          //  this.studentSaved.emit(); // this mean parent-> child after t
         // this.loadStudents();
          this.studentSaved.emit(); //  Notify parent to reload students

           this.cancel();
          },
          error: () => {
            this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Update failed' });
          }
  
        });

      }
    

    }
    else{
      this.studentService.addStudent(this.newStudent).subscribe({
        next: () => {
          this.messageService.add({
            severity: 'success',
            summary: 'Success',
            detail: 'Student added successfully'
          });
       
          
          this.studentSaved.emit();  //  this helps to notify to parent component to succesufully added and  please reload student list
          this.closeDialog.emit();
          this.resetForm();

  
      
         
  
          // this helps to load or show the list of student while student/create . ie using child component to child component ts
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
   
  }

  cancel() {
    this.close();
  }

  private close() {
    this.closeDialog.emit();
    this.resetForm();
    this.router.navigate(['/students']);
  }

  private resetForm() {
    this.newStudent = { name: '', email: '', age: 0 };
  }
}
