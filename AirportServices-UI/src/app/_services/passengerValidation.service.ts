import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PassengerValidationService {

  baseURL = 'https://localhost:5001/api/';

constructor(private http: HttpClient) { }

  validateBooking(model: any) {
    return this.http.post(this.baseURL + 'validate', model);
  }

}
