import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [ AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule
  
  ],
  providers: [],
  // provider is used to register services globally 
  //providing values/config/token..... available in Dependency Injection  Custom or multiple services instance
  bootstrap: [AppComponent]
})
export class AppModule { }
