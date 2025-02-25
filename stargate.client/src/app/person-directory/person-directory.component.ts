import { Component } from '@angular/core';

@Component({
  selector: 'acts-person-directory',
  templateUrl: './person-directory.component.html',
  styleUrl: './person-directory.component.css'
})
export class PersonDirectoryComponent {
  people: PersonAstronautDto[] = [
    {
      personId: 1,
      name: 'Neil Armstrong',
      currentRank: 'Commander',
      currentDutyTitle: 'Apollo 11',
      careerStartDate: new Date('1966-03-16'),
      careerEndDate: new Date('1969-07-24')
    },
    {
      personId: 2,
      name: 'Buzz Aldrin',
      currentRank: 'Lunar Module Pilot',
      currentDutyTitle: 'Apollo 11',
      careerStartDate: new Date('1966-03-16'),
      careerEndDate: new Date('1969-07-24')
    },
    {
      personId: 3,
      name: 'Sally Ride',
      currentRank: 'Mission Specialist',
      currentDutyTitle: 'STS-7',
      careerStartDate: new Date('1978-01-16'),
      careerEndDate: new Date('1987-08-15')
    },
    {
      personId: 4,
      name: 'Chris Hadfield',
      currentRank: 'Commander',
      currentDutyTitle: 'ISS Commander',
      careerStartDate: new Date('1992-06-07'),
      careerEndDate: new Date('2013-07-03')
    }
  ];

  constructor() { }

  ngOnInit(): void { }
}


// ochia - where should I put this?
export interface PersonAstronautDto {
  personId: number;
  name: string;
  currentRank?: string;
  currentDutyTitle?: string;
  careerStartDate?: Date;
  careerEndDate?: Date;
}
