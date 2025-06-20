import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentListComponent } from './components/student-list/student-list.component';
import { StudentFormComponent } from './components/student-form/student-form.component';
import { StudentDetailsComponent } from './components/student-details/student-details.component';
import { StudentsRoutingModule } from './students-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
// CORRECT
import { ConfirmationService } from 'primeng/api';

import { MessageService } from 'primeng/api';
import { HttpClientModule } from '@angular/common/http';




@NgModule({
  declarations: [
    StudentListComponent,
    StudentFormComponent,
    StudentDetailsComponent
  ],
  imports: [
    CommonModule,
    StudentsRoutingModule,
    SharedModule,HttpClientModule
  ],
  providers: [ConfirmationService, MessageService]
})
export class StudentsModule { }
