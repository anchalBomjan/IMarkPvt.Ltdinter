import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentListComponent } from './components/student-list/student-list.component';
import { StudentFormComponent } from './components/student-form/student-form.component';
import { StudentDetailsComponent } from './components/student-details/student-details.component';
import { StudentsRoutingModule } from './students-routing.module';



@NgModule({
  declarations: [
    StudentListComponent,
    StudentFormComponent,
    StudentDetailsComponent
  ],
  imports: [
    CommonModule,
    StudentsRoutingModule
  ]
})
export class StudentsModule { }
