# :face_with_spiral_eyes: :sneezing_face: AllergyAlert :smiling_face_with_tear: :face_exhaling: 

## AllergyAlert is a web application designed to help users monitor allergens in their region. The app provides a list of active allergens based on the user's selected location and the number of days for the forecast. Users can view details about specific allergens, including images and additional information.

## 🚀 Performance Enhancement (September 2024 Update):
Caching: The application leverages <ins>**Microsoft.AspNetCore.ResponseCaching**</ins> to implement a 2-minute response caching mechanism for certain API endpoints, significantly improving performance on repeated calls. The first call usually takes around 1-1.5 seconds, while the second call benefits from caching, taking about 2 milliseconds. This update not only reduces latency for users, but also optimizes resource usage, leading to lower operational costs.

<img width="790" alt="First request timing" src="https://github.com/user-attachments/assets/467dc25e-126f-4729-a09e-964edf5bdd5f">
<img width="792" alt="Second request timing (from cache)" src="https://github.com/user-attachments/assets/deb0ff58-0535-4aa6-856f-6fe46934641c">


## 🔌Technologies Used
**Frontend**: Angular (Standalone Components, Angular CLI)

**Backend**: ASP.NET Core Web API

**🌍Public APIs**:

- **Geocoding API**: 
  https://api-ninjas.com/api/geocoding

- **Pollen API**: 
  https://developers.google.com/maps/documentation/pollen/forecast
  
- **Plant API**: 
  https://perenual.com/docs/api 

https://github.com/user-attachments/assets/6fdbc926-069a-4c6f-829e-c095d5166996


## Installation :floppy_disk:
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

