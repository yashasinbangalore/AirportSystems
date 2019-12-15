import { Component, OnInit } from '@angular/core';
import { PassengerValidationService } from '../_services/passengerValidation.service';


@Component({
  selector: 'app-immigration',
  templateUrl: './immigration.component.html',
  styleUrls: ['./immigration.component.css']
})
export class ImmigrationComponent implements OnInit {
  viewModel: any = {};
  validationResult: any;
  isLoaded = false;
  constructor(private validateService: PassengerValidationService) {

   }

  ngOnInit() {}

  validateBooking() {
    this.isLoaded = false;
    this.validateService.validateBooking(this.viewModel).subscribe(
      response => {
        this.validationResult = response;
        this.isLoaded = true;
      },
      error => {
        this.isLoaded = true;
        console.log(error);
      }
    );
  }

}
