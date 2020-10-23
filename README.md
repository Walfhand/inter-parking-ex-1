# inter-parking-ex-1

Hi, here's the project for Exercise 1.

I use a cqrs architecture.

The project is composed:
-an application project that manages all the common classes, commands, queries, handlers, mappings.

Then a Domain project which manages as its name indicates the domains :) and the business logic.

Then an Infrastructure project that manages all external communications.

In this project you will find the context of the database as well as the geocoding service.


Then you will find a project in asp.net core mvc classic.

I use in this exercise a geolocation api.

https://locationiq.com/

You will find the api key in appsettings.development.json

I use mssql and inMemory database if you want to activate inMemory you can change the value of "UseInMemoryDatabase" to "true" in the appsettings.Development.json file
