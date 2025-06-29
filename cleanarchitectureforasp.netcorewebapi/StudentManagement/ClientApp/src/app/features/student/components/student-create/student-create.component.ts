
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
  private _student: IStudent = {  name: '', email: '', age: 0 };
 
  @Input()
  set student(value: IStudent) {
    this._student = { ...value };

    if (this._mode === 'edit') {
      this.newStudent = { ...this._student };
    } else {
      this.resetForm(); // in case mode is create
    }
  }
  get student(): IStudent {
    return this._student;
  }
  private _mode: 'create' | 'edit' = 'create';

  @Input()
  set mode(value: 'create' | 'edit') {
    this._mode = value;

    // Reset form if mode is create
    if (value === 'create') {
      this.resetForm();
    }
  }

  get mode(): 'create' | 'edit' {
    return this._mode;
  }

  
  @Output() closeDialog = new EventEmitter<void>(); // Emits when the dialog needs to close i.e means using closeDialog of listComponent.ts function so needed to notify to use
  //@Output() studentSaved = new EventEmitter<void>(); // there is no any studentSaved function in listcomponent.ts . we used Studentsaved function of create.comopennt.ts function so no need to notifiy 
  newStudent: IStudent = {  name: '', email: '', age: 0 }; //  this   id for create/student

  constructor( private studentService: StudentService,private messageService: MessageService ,private router:Router ,private cdr: ChangeDetectorRef) 
  {

    this.checkRoute();
    this. loadStudents();

  }


  loadStudents(){
    this.studentService.getAllStudents().subscribe(data=>{
      console.log('student loaded while create/student',data);
    })
  }

  // this  will provide values to open p-diaglog box component.html 
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

    if (this.mode=='edit')
    {
      if(this.newStudent.id!==undefined){
        this.studentService.updateStudent(this.newStudent.id!, this.newStudent).subscribe({
          next: () => {
            this.messageService.add({ severity: 'success', summary: 'Updated', detail: 'Student updated successfully' });
          //  this.studentSaved.emit(); // this mean parent-> child after t
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
        // this.studentSaved.emit(); // Notify parent to reload students  
         this.closeDialog.emit();  // Close the dialog     
         this.resetForm();
  
          /// this below for create/student
       //  this.showCreateDialog=false;       
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
    this.newStudent = {  name: '', email: '', age: 0 };
  }
}
