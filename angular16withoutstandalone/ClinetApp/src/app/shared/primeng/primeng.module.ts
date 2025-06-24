import { NgModule } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { DropdownModule } from 'primeng/dropdown';
import { DialogModule } from 'primeng/dialog';
import { ToolbarModule } from 'primeng/toolbar';  // <-- Add this import

import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
@NgModule({
  declarations: [],
  // borrows tools from other teams
  imports: [
    FormsModule,
    TableModule,
    ButtonModule,
    InputTextModule,
    DropdownModule,
    ToolbarModule,
    DialogModule,
    ToastModule
  ],
  //lending tool to others teams
  exports: [
    FormsModule,
    TableModule,
    ButtonModule,
    InputTextModule,
    DropdownModule,
    ToolbarModule,
    DialogModule,
    ToastModule,
    
  ],
// some tools need employee(providers) for respective tool(import) here ToastModule need MessageService to work
  // provider mean hiring employee(services instance)
  providers:[MessageService]
})
export class PrimengModule { }
