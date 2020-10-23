# inter-parking-ex-1

Hi, here's the project for Exercise 1.

I use a cqrs architecture.

The project is composed:
-an application project that manages all the common classes, commands, queries, handlers, mappings.

Then a Domain project which manages as its name indicates the domains :) and the business logic.

Then an Infrastructure project that manages all external communications.

In this project you will find the context of the database as well as the geocoding service.


Then you will find a project in asp.net core mvc classic.

You will essentially find 2 controllers that will interest you.

ParkingController -> which will manage the addition, retrieval and updating of parking lots.

ItineraryController -> which will manage the creation, retrieval and update of itineraries.

You will see 3 different tabs.

1 tab Parking
1 tab Itineraries
1 tab report

In the parking tab you will be able to :

Add parking lots,
See the list of parking lots,
Edit a parking lot,

In the Itineraries tab you will be able to:

Add itineraries,
See the list of itineraries,
Edit itineraries

In the report tab you will be able to see a summary of the data entered and calculated by the system.

I use in this exercise a geolocation api.

https://locationiq.com/

You will find the api key in appsettings.development.json

I use mssql and inMemory database if you want to activate inMemory you can change the value of "UseInMemoryDatabase" to "true" in the appsettings.Development.json file
