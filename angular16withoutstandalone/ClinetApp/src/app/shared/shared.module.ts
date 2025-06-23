import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { PrimengModule } from './primeng/primeng.module';



@NgModule({
  declarations: [
    // this mean after declartion you can able to used all imported module by declarationin here
    NavbarComponent
  ],
  // model that are imported to make avaiable for declara componets and exports modules
  imports: [CommonModule,RouterModule,PrimengModule],

  //things  to avaiable for other modules i.e 2 module you can get throught sharedmodule import
  exports:[NavbarComponent,PrimengModule]
})
export class SharedModule { }
