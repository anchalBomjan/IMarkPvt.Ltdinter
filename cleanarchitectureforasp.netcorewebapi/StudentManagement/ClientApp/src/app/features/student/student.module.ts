import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentRoutingModule } from './student-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { RouterModule } from '@angular/router';
import { StudentCreateComponent } from './components/student-create/student-create.component';
import { StudentEditComponent } from './components/student-edit/student-edit.component';
import { StudentListComponent } from './components/student-list/student-list.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    StudentListComponent,
    StudentEditComponent,
    StudentCreateComponent
  ],
  imports: [
    CommonModule,
    StudentRoutingModule,
    SharedModule,
    RouterModule,
    ReactiveFormsModule
  ]
})
export class StudentModule { }


