import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/Forms';

import { AppComponent } from './app.component';
import { ImmigrationComponent } from './immigration/immigration.component';
import { PassengerValidationService } from './_services/passengerValidation.service';

@NgModule({
   declarations: [
      AppComponent,
      ImmigrationComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      PassengerValidationService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
