# AirportSystems
Vedaleon Airport systems code base that contains web services and front end application

The AirportServices.API contains the Web API built on ASP.NET Core

The AirportServices-UI contains the front end to validate the passenger based on passenger name and Airport, built on Angular 8.

Before running the API, update the "BookingDataPath" configuration value in the appSettings.json file accordingly for the bookings.json file and then run the Web API.

API documentation available in below path after running the web API application : http://localhost:5000/swagger

The GUI application in AirportServices-UI just contains one page, where immigration officer would enter passenger name and Airport, based on which result would be displayed which could either be an error, warning or a successful message 


