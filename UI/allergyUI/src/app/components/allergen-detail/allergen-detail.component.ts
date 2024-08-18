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
  plantInfo: any = null;

  constructor(private allergyService: AllergyService) {}

  ngOnChanges() {
    if (this.allergen) {
      this.allergyService.getPlantInfo(this.allergen.displayName).subscribe(response => {
        this.plantInfo = response;  // Store the entire response object
      });
    }
  }
}
