# Weather App

## Summary
This project consists of a simple web application that gets weather information for 3 cities:
* Dublin
* Barcelona
* New York

The user can select the one of the cities from the dropdown, click "Get Weather" and the details will appear below.

There are two separate parts: the API project and the client app project.

The API Project was built using .NET 6 and the client app was built with Vue.js.

## Building / Running the App
### API
* Install .NET 6
* Open the command prompt and run the following:
```
cd Api
cd WeatherApi
dotnet run
```

The API will run on [https://localhost:7058](https://localhost:7058)

To view the Swagger documentation, go to [https://localhost:7058/swagger](https://localhost:7058/swagger)

### Client app
* Install Node v16.0.0 or higher
* Open the command prompt and run the following:
```
cd Client
npm install
npm run dev
```

The URL for the client app will appear in the terminal.

No further setup is required.