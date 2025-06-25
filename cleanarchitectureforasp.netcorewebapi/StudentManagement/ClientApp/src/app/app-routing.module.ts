import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'students', loadChildren: () => import('./features/student/student.module').then(m => m.StudentModule) },
  { path: '', redirectTo: 'students', pathMatch: 'full' }
];



@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)]
,
exports:[RouterModule]

})
export class AppRoutingModule { }
