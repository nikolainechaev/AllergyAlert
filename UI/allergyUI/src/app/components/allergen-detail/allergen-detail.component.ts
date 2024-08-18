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
  imageUrl: string | null = null;

  constructor(private allergyService: AllergyService) {}

  ngOnChanges() {
    if (this.allergen) {
      this.allergyService.getPlantPicture(this.allergen.displayName).subscribe(response => {
        this.imageUrl = response.imageUrl;  // Note the 'ImageUrl' key matches your backend response
      });
    }
  }
}
