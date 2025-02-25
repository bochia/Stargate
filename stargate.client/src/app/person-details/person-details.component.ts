import { Component } from '@angular/core';
import { PeopleService } from '../services/people.service';
import { PersonAstronautDto } from '../person-directory/person-directory.component';
import { ActivatedRoute } from '@angular/router';
import { AstronautDutyDto } from '../models/AstronautDutyDto';
import { DutyService } from '../services/duty.service';

@Component({
  selector: 'acts-person-details',
  templateUrl: './person-details.component.html',
  styleUrl: './person-details.component.css'
})
export class PersonDetailsComponent {
  id: number = 0;
  person: PersonAstronautDto | null = null;
  duties: AstronautDutyDto[] | null = null;

  constructor(private peopleService: PeopleService, private dutyService: DutyService, private route: ActivatedRoute) {
    this.route.params.subscribe((params) => {
      this.id = params['id'] ?? '';
    });
  }

  ngOnInit() {
    if (this.id > 0) {
      this.peopleService.getPerson(this.id).subscribe(apiResponse => {
        this.person = apiResponse.person;
      });

      this.dutyService.getAstronautDutiesByPersonId(this.id).subscribe(apiResponse => {
        console.log(apiResponse.astronautDuties);
        this.duties = apiResponse.astronautDuties;
      })
    }
  }

  getValueForUI(value: any): string {
    if (!value) {
      return 'N/A'
    }

    return value;
  }
}
