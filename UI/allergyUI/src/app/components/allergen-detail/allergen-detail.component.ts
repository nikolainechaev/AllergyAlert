import { Component, Input, OnChanges } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllergyService } from '../../services/allergy.service';

@Component({
  selector: 'app-allergen-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './allergen-detail.component.html',
  styleUrls: ['./allergen-detail.component.css'],
})
export class AllergenDetailComponent implements OnChanges {
  @Input() allergen: any;
  @Input() plantInfo: any = null;
  
  showDetails = false;

  constructor(private allergyService: AllergyService) {}

  ngOnChanges() {
    this.showDetails = false; // Reset the details view when allergen changes
  }
}
