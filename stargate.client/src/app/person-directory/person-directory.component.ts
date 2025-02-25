import { Component } from '@angular/core';
import { PersonAstronautDto } from '../models/PersonAstronautDto';
import { PeopleService } from '../services/people.service';

@Component({
  selector: 'acts-person-directory',
  templateUrl: './person-directory.component.html',
  styleUrl: './person-directory.component.css'
})
export class PersonDirectoryComponent {
  allPeople: PersonAstronautDto[] | null;
  filteredPeople: PersonAstronautDto[] | null;

  constructor(private peopleService: PeopleService) {
    this.allPeople = null;
    this.filteredPeople = null;
  }

  ngOnInit() {
    this.peopleService.getPeople().subscribe(apiResponse => {
      this.allPeople = apiResponse.people;
      this.filteredPeople = this.allPeople;
    });
  }

  filterTable(searchText: string) {
    // ochia - in the future I would make this go back to the server and get a new list. For now doing it the quick and dirt way.
    if (!searchText) {
      this.filteredPeople = this.allPeople;
    }

    // make it case insensitive for searching b/c its more friend to the user.
    this.filteredPeople = this.allPeople?.filter(x => x.name.toLowerCase().includes(searchText.toLowerCase())) ?? null;
  }

  getValueForUI(value: any): string {
    if (!value) {
      return 'N/A'
    }

    return value;
  }

  // ochia - want to add search functionality to this with a textbox, button and pass the search value into this and then filter down the list.
}

export { PersonAstronautDto };
