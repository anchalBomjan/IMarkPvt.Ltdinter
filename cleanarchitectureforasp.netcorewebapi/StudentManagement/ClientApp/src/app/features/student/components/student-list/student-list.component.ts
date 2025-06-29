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
  newStudent: IStudent = { name: '', email: '', age: 0 };


   constructor( private studentService: StudentService, private messageService: MessageService,private router: Router,private route:ActivatedRoute)
   {
    this.loadStudents();
    
 

     // we have components that deals with both  edit and delete operation throught p-dialog box  so we doneed to do this snap.shot
    // this.router.events.subscribe(event => {
    //   if (event instanceof NavigationEnd) {
    //     const url = event.urlAfterRedirects;
  
    //     const id = this.route.snapshot.paramMap.get('id');
  
    //     if (url.includes('/students/edit') && id) {
    //       this.openEditDialog(+id);
    //     }
  
    //     if (url.includes('/students/create')) {
    //       this.openCreateDialog();
    //     }
    //   }
    // });
   }

  loadStudents(): void {
    this.studentService.getAllStudents().subscribe(data => {
      this.students = data;

      console.log('Student loaded',data);
    });
  }


  // if we used P-dialog box for edit then used this typeSS
  openEditDialog(id:number){
    this.mode='edit';
    this.studentService.getStudentById(id).subscribe(student=>{
      console.log("edit details:", student);
      this.newStudent={...student};


      //  from this traditional way unable to load while editing so we used spread operation as above
      // this.newStudent.name=student.name;
      // this.newStudent.email=student.email;
      // this.newStudent.age=student.age;

      // setTimeout(()=>{
      //   this.showCreateDialog =true;

      // },0);
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
    this.mode='create';
    this.newStudent={name:'',email:'',age:0}; // this is necessary to  reset form data while using same templete for edit and delete throught dialog box
    this.showCreateDialog = true;
  }

 

  //  // if used seperate component for edit then  used like this 
  // editStudent(id: number) {
  //   this.router.navigate(['/students/edit', id]);
  // }

}

