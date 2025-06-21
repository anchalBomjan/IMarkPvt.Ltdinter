import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { PrimengModule } from './primeng/primeng.module';



@NgModule({
  declarations: [
    NavbarComponent
  ],
  imports: [CommonModule,RouterModule,PrimengModule],
  exports:[NavbarComponent,PrimengModule]
})
export class SharedModule { }
