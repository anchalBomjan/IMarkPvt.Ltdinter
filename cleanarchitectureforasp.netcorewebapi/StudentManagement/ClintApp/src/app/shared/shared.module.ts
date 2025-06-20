import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './components/loader.component';
import { PrimeNgModule } from './prime-ng.module';



@NgModule({
  declarations: [
    LoaderComponent
  ],
  imports: [
    CommonModule,
    PrimeNgModule
  ],
  exports: [
    LoaderComponent
  ]
})
export class SharedModule { }
