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
  isLoading: boolean;
  isError: boolean;
  constructor(private validateService: PassengerValidationService) {

   }

  ngOnInit() {
    this.isLoading = false;
    this.isError = false;
  }

  validateBooking() {
    this.isLoading = true;
    this.isError = false;
    this.validateService.validateBooking(this.viewModel).subscribe(
      response => {
        this.validationResult = response;
        this.isLoading = false;
      },
      error => {
        console.log(error);
        this.isLoading = false;
        this.isError = true;
      }
    );
  }

  isValidated() {
    return !!this.validationResult;
  }

}
