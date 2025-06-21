import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentRoutingModule } from './student-routing.module';
import { StudentCreateComponent } from './components/student-create/student-create.component';
import { StudentEditComponent } from './components/student-edit/student-edit.component';
import { StudentListComponent } from './components/student-list/student-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import {  RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    StudentCreateComponent,
    StudentEditComponent,
    StudentListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    StudentRoutingModule
  ]
})
export class StudentModule { }
