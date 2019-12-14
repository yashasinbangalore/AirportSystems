import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-immigration',
  templateUrl: './immigration.component.html',
  styleUrls: ['./immigration.component.css']
})
export class ImmigrationComponent implements OnInit {
  bookings: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.searchBookings();
  }

  searchBookings(){
    this.http.get('http://localhost:5000/api/bookings/Harry').subscribe(
      response => { this.bookings = response; },
      error => { console.log(error); }
    );
  }

}
