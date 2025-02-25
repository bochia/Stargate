import { Component } from '@angular/core';
import { PeopleService } from '../people.service';
import { PersonAstronautDto } from '../person-directory/person-directory.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'acts-person-details',
  templateUrl: './person-details.component.html',
  styleUrl: './person-details.component.css'
})
export class PersonDetailsComponent {
  name: string = '';
  person: PersonAstronautDto | undefined;

  constructor(private peopleService: PeopleService, private route: ActivatedRoute) {
    this.route.params.subscribe((params) => {
      this.name = params['name'] ?? '';
    });
  }

  ngOnInit() {
    if (this.name) {
      this.peopleService.getPerson(this.name).subscribe(apiResponse => {

        console.log(apiResponse);
        this.person = apiResponse.person;
      });
    }
  }
}
