import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-search-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.css']
})
export class SearchFormComponent {
  city: string = '';
  state: string = '';
  days: number = 1;

  @Output() search = new EventEmitter<{ city: string, state: string, days: number }>();

  onSubmit() {
    this.search.emit({ city: this.city, state: this.state, days: this.days });
  }
}
