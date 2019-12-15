/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PassengerValidationService } from './passengerValidation.service';

describe('Service: PassengerValidation', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PassengerValidationService]
    });
  });

  it('should ...', inject([PassengerValidationService], (service: PassengerValidationService) => {
    expect(service).toBeTruthy();
  }));
});
