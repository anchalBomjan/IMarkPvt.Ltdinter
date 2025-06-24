import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from './shared/shared.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,   // this helps to run the angular Application
    AppRoutingModule,
    SharedModule,  // bezc app.component uses navbar
    BrowserAnimationsModule,  // enables animations in our  Anular Application
    HttpClientModule  // enables communication with backedend  services using HTTP Protocols


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
