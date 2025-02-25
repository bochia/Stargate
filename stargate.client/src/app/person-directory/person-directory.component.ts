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

  filterTable() {
    // ochia - need to add real filtering later.
    this.people =  [
      { personId: 1, name: 'Neil Armstrong', currentRank: 'Commander', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
      { personId: 2, name: 'Buzz Aldrin', currentRank: 'Lunar Module Pilot', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
      { personId: 3, name: 'Sally Ride', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-7', careerStartDate: new Date('1978-01-16'), careerEndDate: new Date('1987-08-15') },
    ];
  }
}

export { PersonAstronautDto };
