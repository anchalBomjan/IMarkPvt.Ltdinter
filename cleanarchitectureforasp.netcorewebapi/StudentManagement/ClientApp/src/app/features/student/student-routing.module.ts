import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentListComponent } from './components/student-list/student-list.component';
import { StudentCreateComponent } from './components/student-create/student-create.component';
import { StudentEditComponent } from './components/student-edit/student-edit.component';

// const routes:Routes=[
// {path:'',component:StudentListComponent},
// {path:'students',component:StudentListComponent},
// {path:'students/create',component:StudentCreateComponent},
// {path:'students/edit/:id',component:StudentEditComponent}

// ];
const routes: Routes = [
  { path: '', component: StudentListComponent },
  { path: 'create', component: StudentCreateComponent },
  { path: 'edit/:id', component: StudentEditComponent },

];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentRoutingModule { }
