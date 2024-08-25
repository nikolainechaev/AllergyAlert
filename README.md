# AllergyAlert

## AllergyAlert is a web application designed to help users monitor allergens in their region. The app provides a list of active allergens based on the user's selected location and the number of days for the forecast. Users can view details about specific allergens, including images and additional information.
## Technologies Used
**Frontend**: Angular (Standalone Components, Angular CLI)

**Backend**: ASP.NET Core Web API

**Public APIs**:

- **Geocoding API**: 
  https://api-ninjas.com/api/geocoding

- **Pollen API**: 
  https://developers.google.com/maps/documentation/pollen/forecast
  
- **Plant API**: 
  https://perenual.com/docs/api 

https://github.com/user-attachments/assets/6fdbc926-069a-4c6f-829e-c095d5166996


## Installation
Follow these steps to run the application locally:

### Prerequisites
* You will need to register with the API providers mentioned above to get API keys. After that, create three environment variables to securely store the API keys:

  * ```GEOCODING_ENV```
  
  * ```POLLEN_FORECAST_ENV``` 
  
  * ```PLANT_INFO_ENV```
  

* Node.js and npm installed on your machine

* .NET SDK installed

* Angular CLI installed globally 

### Frontend Setup

* Clone the Repository:
```git clone https://github.com/yourusername/allergyalert.git```

* cd into project:
```cd allergyalert/UI/allergyUI```

* Install Dependencies:
```npm install``` 

* Run server:
```ng serve```

* The app should be running at http://localhost:4200.

### Backend Setup
* Navigate to the Backend Directory:
```cd ../allergyAPI```

* Install Dependencies and Restore NuGet Packages:
```dotnet restore```

* Run the ASP.NET Core Web API:
```dotnet run```

* The API should be running at http://localhost:5269.

