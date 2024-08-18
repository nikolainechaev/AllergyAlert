import { Component } from '@angular/core';
import { SearchFormComponent } from './components/search-form/search-form.component';
import { ForecastListComponent } from './components/forecast-list/forecast-list.component';
import { AllergenDetailComponent } from './components/allergen-detail/allergen-detail.component';
import { AllergyService } from './services/allergy.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    SearchFormComponent,
    ForecastListComponent,
    AllergenDetailComponent,
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  allergens: any[] = [];
  selectedAllergen: any = null;
  plantImageUrl: string | null = null;

  constructor(private allergyService: AllergyService) {}

  onSearch({ city, state, days }: { city: string, state: string, days: number }) {
    this.allergyService.getPollenForecast(city, state, days).subscribe((response: any) => {
      if (response && response.dailyInfo) {
        this.allergens = response.dailyInfo.flatMap((info: any) => info.plantInfo);
      } else {
        this.allergens = [];
      }
    });
  }

  onAllergenSelected(allergen: any) {
    this.selectedAllergen = allergen;
    this.allergyService.getPlantPicture(allergen.displayName).subscribe((response: any) => {
      this.plantImageUrl = response.ImageUrl;
    });
  }
}
