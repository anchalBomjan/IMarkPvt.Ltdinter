import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './components/loader.component';
import { PrimeNgModule } from './prime-ng.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LoaderComponent
  ],
  imports: [CommonModule, ReactiveFormsModule, PrimeNgModule,],
  exports: [LoaderComponent, ReactiveFormsModule, PrimeNgModule]
})
export class SharedModule { }
