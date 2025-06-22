import { NgModule } from '@angular/core';

import { StudentRoutingModule } from './student-routing.module';
import { StudentCreateComponent } from './components/student-create/student-create.component';
import { StudentEditComponent } from './components/student-edit/student-edit.component';
import { StudentListComponent } from './components/student-list/student-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import {  RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [

    //  imports modules are used by this components so declartion here
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
