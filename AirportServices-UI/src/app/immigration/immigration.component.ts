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
  constructor(private validateService: PassengerValidationService) {

   }

  ngOnInit() {}

  validateBooking() {
    this.validateService.validateBooking(this.viewModel).subscribe(
      response => {
        this.validationResult = response;
      },
      error => {
        console.log(error);
      }
    );
  }

  isValidated() {
    return !!this.validationResult;
  }

}
