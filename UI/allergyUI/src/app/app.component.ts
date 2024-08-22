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
  plantInfo: any = null;
  showDetailsView = false;
  headerText: string = '';

  constructor(private allergyService: AllergyService) {}

  onSearch({ city, state, days }: { city: string, state: string, days: number }) {
    // Reset data before making the API call
    this.allergens = [];
    this.selectedAllergen = null;
    this.plantInfo = null;
    this.headerText = '';

    this.allergyService.getPollenForecast(city, state, days).subscribe((response: any) => {
      if (response && response.dailyInfo) {
        this.allergens = this.removeDuplicates(response.dailyInfo.flatMap((info: any) => info.plantInfo));
        this.headerText = this.generateHeaderText(city, days);
      } else {
        this.allergens = [];
        this.headerText = 'No active allergens found.';
      }
    });
  }

  generateHeaderText(city: string, days: number): string {
    return `This is the list of active allergens near the region ${city} for the next ${days} days:`;
  }

  removeDuplicates(allergens: any[]): any[] {
    const uniqueAllergens: any[] = [];
    const allergenNames = new Set();

    allergens.forEach(allergen => {
      if (!allergenNames.has(allergen.displayName)) {
        allergenNames.add(allergen.displayName);
        uniqueAllergens.push(allergen);
      }
    });

    return uniqueAllergens;
  }

  onAllergenSelected(allergen: any) {
    this.selectedAllergen = allergen;
    this.showDetailsView = true;
    this.allergyService.getPlantInfo(allergen.displayName).subscribe((response: any) => {
      this.plantInfo = response;
    });
  }

  onHideDetails() {
    this.showDetailsView = false;
  }
}
