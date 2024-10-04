import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'  // This makes the service available globally
})
export class AllergyService {
  private apiUrl = 'http://localhost:5269/api/AllergyForecast'; // Adjust this URL as needed

  constructor(private http: HttpClient) {}

  getPollenForecast(city: string, country: string, days: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/forecast`, {
      params: { city, country, days }
    });
  }

  getPlantInfo(plant: string): Observable<any> {
    return this.http.get(`${this.apiUrl}/plant/${plant}`, {
      params: { plant }
    });
  }
}
