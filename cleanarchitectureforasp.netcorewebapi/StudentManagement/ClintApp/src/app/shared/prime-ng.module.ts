import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { ToastModule } from 'primeng/toast';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { CalendarModule } from 'primeng/calendar';


@NgModule({
  exports: [
    ButtonModule,
    TableModule,
    ToastModule,
    ConfirmDialogModule,
    DialogModule,
    InputTextModule,
    CalendarModule
  ]
})



export class PrimeNgModule { }
