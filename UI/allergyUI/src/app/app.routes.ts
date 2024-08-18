import { Routes } from '@angular/router';
import { SearchFormComponent } from './components/search-form/search-form.component';
import { ForecastListComponent } from './components/forecast-list/forecast-list.component';
import { AllergenDetailComponent } from './components/allergen-detail/allergen-detail.component';

export const routes: Routes = [
  { path: '', redirectTo: '/search', pathMatch: 'full' },
  { path: 'search', component: SearchFormComponent },
  { path: 'forecast', component: ForecastListComponent },
  { path: 'detail', component: AllergenDetailComponent },
];
