import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-forecast-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './forecast-list.component.html',
  styleUrls: ['./forecast-list.component.css']
})
export class ForecastListComponent {
  @Input() allergens: any[] = [];
  @Output() allergenSelected = new EventEmitter<any>();

  viewDetails(allergen: any) {
    this.allergenSelected.emit(allergen);
  }
}