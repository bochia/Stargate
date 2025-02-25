import { Component } from '@angular/core';
import { PersonAstronautDto } from '../models/PersonAstronautDto';
import { PeopleService } from '../services/people.service';

@Component({
  selector: 'acts-person-directory',
  templateUrl: './person-directory.component.html',
  styleUrl: './person-directory.component.css'
})
export class PersonDirectoryComponent {
  people: PersonAstronautDto[] | null;

  constructor(private peopleService: PeopleService) {
    this.people = null;
  }

  ngOnInit() {
    this.peopleService.getPeople().subscribe(apiResponse => {
      this.people = apiResponse.people;
    });
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
