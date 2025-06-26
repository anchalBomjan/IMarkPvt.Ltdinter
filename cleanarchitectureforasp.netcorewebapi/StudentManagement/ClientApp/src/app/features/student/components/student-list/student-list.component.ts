import { Component } from '@angular/core';
import { IStudent } from 'src/app/core/models/student';
import { MessageService } from 'primeng/api';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { StudentService } from 'src/app/core/services/Student.Service';

@Component({
  selector: 'app-student-list',
  templateUrl: './student-list.component.html',
  styleUrls: ['./student-list.component.scss'],
  providers: [MessageService]
})
export class StudentListComponent {
  students: IStudent[] = [];
  showDeleteDialog = false;
  showCreateDialog = false;
  selectedStudentId: number | null = null;


  mode:'create'|'edit'='create';
  newStudent: IStudent = {id:0, name: '', email: '', age: 0 };


   constructor( private studentService: StudentService, private messageService: MessageService,private router: Router,private route:ActivatedRoute)
   {
    this.loadStudents();
    
 

    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        const url = event.urlAfterRedirects;
  
        const id = this.route.snapshot.paramMap.get('id');
  
        if (url.includes('/students/edit') && id) {
          this.openEditDialog(+id);
        }
  
        if (url.includes('/students/create')) {
          this.openCreateDialog();
        }
      }
    });
   }

  loadStudents(): void {
    this.studentService.getAllStudents().subscribe(data => {
      this.students = data;

      console.log('Student loaded',data);
    });
  }

  openEditDialog(id:number){
    this.mode='edit';
    this.studentService.getStudentById(id).subscribe(student=>{
      console.log("edit details:", student);
      //this.newStudent={...student};

      this.newStudent.id=student.id;
      this.newStudent.name=student.name;
      this.newStudent.email=student.email;
      this.newStudent.age=student.age;

      this.showCreateDialog =true;
    })
  }
  openDeleteDialog(id: number) {
    this.selectedStudentId = id;
    this.showDeleteDialog = true;
  }

  confirmDelete() {
    if (this.selectedStudentId !== null) {
      this.studentService.deleteStudent(this.selectedStudentId).subscribe(() => {
        this.messageService.add({
          severity: 'success',
          summary: 'Deleted',
          detail: 'Student deleted successfully'
        });
        this.showDeleteDialog = false;
        this.selectedStudentId = null;
        this.loadStudents();
      });
    }
  }

  cancelDelete() {
    this.showDeleteDialog = false;
    this.selectedStudentId = null;
  }

  openCreateDialog() {
    this.showCreateDialog = true;
  }

  saveStudent() {
    console.log('Saving Student:', this.newStudent);// Log the student data veing sent
    if(this.mode=='edit'){

      

    } else{
      this.studentService.addStudent(this.newStudent).subscribe({
   
        next:(response)=>{
          console.log('Student saved successfully:',response);
          this.messageService.add({
            severity:'success',
            summary:'success',
            detail:'Student added successfully'
  
          });
  
          this.showCreateDialog=false;
          this.loadStudents();
        },
  
        error:(error)=>{
        console.log('Error saving student',error);
        this.messageService.add({
          severity:'error',
          summary:'eror',
          detail:' fail to load'
        })
        }
      });



    }
  
  }
  editStudent(id: number) {
    this.router.navigate(['/students/edit', id]);
  }

}

