import { Component } from '@angular/core';

@Component({
  selector: 'acts-person-directory',
  templateUrl: './person-directory.component.html',
  styleUrl: './person-directory.component.css'
})
export class PersonDirectoryComponent {
  people: PersonAstronautDto[] = [
    { personId: 1, name: 'Neil Armstrong', currentRank: 'Commander', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
    { personId: 2, name: 'Buzz Aldrin', currentRank: 'Lunar Module Pilot', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
    { personId: 3, name: 'Sally Ride', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-7', careerStartDate: new Date('1978-01-16'), careerEndDate: new Date('1987-08-15') },
    { personId: 4, name: 'Chris Hadfield', currentRank: 'Commander', currentDutyTitle: 'ISS Commander', careerStartDate: new Date('1992-06-07'), careerEndDate: new Date('2013-07-03') },
    { personId: 5, name: 'Mae Jemison', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-47', careerStartDate: new Date('1987-06-05'), careerEndDate: new Date('1993-04-28') },
    { personId: 6, name: 'Yuri Gagarin', currentRank: 'Pilot', currentDutyTitle: 'Vostok 1', careerStartDate: new Date('1961-04-12'), careerEndDate: new Date('1961-04-12') },
    { personId: 7, name: 'Valentina Tereshkova', currentRank: 'Pilot', currentDutyTitle: 'Vostok 6', careerStartDate: new Date('1963-06-16'), careerEndDate: new Date('1963-06-19') },
    { personId: 8, name: 'John Glenn', currentRank: 'Colonel', currentDutyTitle: 'Mercury-Atlas 6', careerStartDate: new Date('1959-02-20'), careerEndDate: new Date('1998-10-29') },
    { personId: 9, name: 'Alan Shepard', currentRank: 'Commander', currentDutyTitle: 'Freedom 7', careerStartDate: new Date('1961-05-05'), careerEndDate: new Date('1971-07-31') },
    { personId: 10, name: 'Gennady Padalka', currentRank: 'Colonel', currentDutyTitle: 'Soyuz TMA-4', careerStartDate: new Date('1998-03-31'), careerEndDate: new Date('2015-09-12') },
    { personId: 11, name: 'Peggy Whitson', currentRank: 'Astronaut', currentDutyTitle: 'Expedition 16', careerStartDate: new Date('1996-07-05'), careerEndDate: new Date('2017-09-03') },
    { personId: 12, name: 'Scott Kelly', currentRank: 'Commander', currentDutyTitle: 'Expedition 45', careerStartDate: new Date('1999-11-25'), careerEndDate: new Date('2016-03-01') },
    { personId: 13, name: 'Michael Collins', currentRank: 'Command Module Pilot', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
    { personId: 14, name: 'Jim Lovell', currentRank: 'Captain', currentDutyTitle: 'Apollo 13', careerStartDate: new Date('1967-12-21'), careerEndDate: new Date('1973-04-15') },
    { personId: 15, name: 'Eileen Collins', currentRank: 'Colonel', currentDutyTitle: 'STS-63', careerStartDate: new Date('1990-07-23'), careerEndDate: new Date('2006-07-01') },
    { personId: 16, name: 'Franklin Chang-Díaz', currentRank: 'Commander', currentDutyTitle: 'STS-61-C', careerStartDate: new Date('1986-01-12'), careerEndDate: new Date('2005-07-12') },
    { personId: 17, name: 'Kathryn Sullivan', currentRank: 'Captain', currentDutyTitle: 'STS-41-G', careerStartDate: new Date('1984-10-05'), careerEndDate: new Date('1993-01-19') },
    { personId: 18, name: 'Jim Bridenstine', currentRank: 'Administrator', currentDutyTitle: 'NASA Administrator', careerStartDate: new Date('2018-04-23'), careerEndDate: new Date('2021-01-20') },
    { personId: 19, name: 'Charles Bolden', currentRank: 'General', currentDutyTitle: 'NASA Administrator', careerStartDate: new Date('2009-07-17'), careerEndDate: new Date('2017-01-20') },
    { personId: 20, name: 'Alan Bean', currentRank: 'Commander', currentDutyTitle: 'Apollo 12', careerStartDate: new Date('1969-11-14'), careerEndDate: new Date('1973-11-05') },
    { personId: 21, name: 'Jack Swigert', currentRank: 'Command Module Pilot', currentDutyTitle: 'Apollo 13', careerStartDate: new Date('1970-04-11'), careerEndDate: new Date('1970-04-14') },
    { personId: 22, name: 'Lori Garver', currentRank: 'Deputy Administrator', currentDutyTitle: 'NASA Deputy Administrator', careerStartDate: new Date('2009-07-17'), careerEndDate: new Date('2013-09-01') },
    { personId: 23, name: 'Tom Marshburn', currentRank: 'Commander', currentDutyTitle: 'Expedition 34', careerStartDate: new Date('2012-12-19'), careerEndDate: new Date('2013-05-14') },
    { personId: 24, name: 'Chris Cassidy', currentRank: 'Captain', currentDutyTitle: 'Expedition 35', careerStartDate: new Date('2004-06-26'), careerEndDate: new Date('2017-08-21') },
    { personId: 25, name: 'Barbara Morgan', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-118', careerStartDate: new Date('1998-08-21'), careerEndDate: new Date('2007-08-08') },
    { personId: 26, name: 'Susan Helms', currentRank: 'Colonel', currentDutyTitle: 'STS-54', careerStartDate: new Date('1993-01-13'), careerEndDate: new Date('2002-02-19') },
    { personId: 27, name: 'Robert Curbeam', currentRank: 'Captain', currentDutyTitle: 'STS-98', careerStartDate: new Date('1999-11-20'), careerEndDate: new Date('2004-12-22') },
    { personId: 28, name: 'Steven Lindsey', currentRank: 'Colonel', currentDutyTitle: 'STS-87', careerStartDate: new Date('1995-12-06'), careerEndDate: new Date('2008-07-12') },
    { personId: 29, name: 'David Brown', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-107', careerStartDate: new Date('1998-07-12'), careerEndDate: new Date('2003-02-01') },
    { personId: 30, name: 'Rick D. Husband', currentRank: 'Commander', currentDutyTitle: 'STS-107', careerStartDate: new Date('1994-07-05'), careerEndDate: new Date('2003-02-01') },
    { personId: 31, name: 'Kalpana Chawla', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-107', careerStartDate: new Date('1997-11-19'), careerEndDate: new Date('2003-02-01') },
    { personId: 32, name: 'Don Pettit', currentRank: 'Astronaut', currentDutyTitle: 'Expedition 6', careerStartDate: new Date('1996-06-17'), careerEndDate: new Date('2012-10-11') },
    { personId: 33, name: 'John M. Lounge', currentRank: 'Colonel', currentDutyTitle: 'STS-51-L', careerStartDate: new Date('1985-01-24'), careerEndDate: new Date('1986-01-28') },
    { personId: 34, name: 'Robert Gibson', currentRank: 'Colonel', currentDutyTitle: 'STS-47', careerStartDate: new Date('1988-09-12'), careerEndDate: new Date('1996-07-23') },
    { personId: 35, name: 'Wendy Lawrence', currentRank: 'Captain', currentDutyTitle: 'STS-67', careerStartDate: new Date('1995-03-04'), careerEndDate: new Date('2002-11-04') },
    { personId: 36, name: 'George Zamka', currentRank: 'Colonel', currentDutyTitle: 'STS-130', careerStartDate: new Date('1994-07-25'), careerEndDate: new Date('2010-02-24') },
    { personId: 37, name: 'Stephen G. Bowen', currentRank: 'Captain', currentDutyTitle: 'STS-126', careerStartDate: new Date('2000-05-06'), careerEndDate: new Date('2011-05-22') },
    { personId: 38, name: 'Leland Melvin', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-122', careerStartDate: new Date('2002-01-12'), careerEndDate: new Date('2014-01-26') },
    { personId: 39, name: 'Richard Arnold', currentRank: 'Lieutenant Colonel', currentDutyTitle: 'STS-51-B', careerStartDate: new Date('1985-04-29'), careerEndDate: new Date('1997-03-17') },
    { personId: 40, name: 'Randy Bresnik', currentRank: 'Colonel', currentDutyTitle: 'Expedition 52', careerStartDate: new Date('2009-07-12'), careerEndDate: new Date('2017-01-01') },
    { personId: 41, name: 'Robert Hines', currentRank: 'Lieutenant Colonel', currentDutyTitle: 'STS-64', careerStartDate: new Date('1992-09-09'), careerEndDate: new Date('2013-10-01') },
    { personId: 42, name: 'Douglas Wheelock', currentRank: 'Colonel', currentDutyTitle: 'Expedition 24', careerStartDate: new Date('1998-07-12'), careerEndDate: new Date('2011-11-17') },
    { personId: 43, name: 'Catherine Coleman', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-73', careerStartDate: new Date('1992-06-26'), careerEndDate: new Date('2009-04-15') },
    { personId: 44, name: 'Jules Verne', currentRank: 'Engineer', currentDutyTitle: 'Ariane 5', careerStartDate: new Date('2004-03-04'), careerEndDate: new Date('2006-06-10') },
    { personId: 45, name: 'Charlie Duke', currentRank: 'Astronaut', currentDutyTitle: 'Apollo 16', careerStartDate: new Date('1969-04-16'), careerEndDate: new Date('1972-04-27') },
    { personId: 46, name: 'Gene Cernan', currentRank: 'Captain', currentDutyTitle: 'Apollo 17', careerStartDate: new Date('1972-12-07'), careerEndDate: new Date('1972-12-19') },
    { personId: 47, name: 'Fred Leslie', currentRank: 'Engineer', currentDutyTitle: 'ISS', careerStartDate: new Date('2001-03-15'), careerEndDate: new Date('2010-08-02') },
    { personId: 48, name: 'Janet Kavandi', currentRank: 'Commander', currentDutyTitle: 'STS-91', careerStartDate: new Date('1994-06-07'), careerEndDate: new Date('2001-07-11') },
    { personId: 49, name: 'David McBride', currentRank: 'Lieutenant Colonel', currentDutyTitle: 'STS-116', careerStartDate: new Date('2005-12-09'), careerEndDate: new Date('2008-12-01') },
    { personId: 50, name: 'Janet D. Rochford', currentRank: 'Major', currentDutyTitle: 'STS-63', careerStartDate: new Date('1995-06-17'), careerEndDate: new Date('2001-06-12') }
  ];

  constructor() { }

  ngOnInit(): void { }

  filterTable() {
    this.people =  [
      { personId: 1, name: 'Neil Armstrong', currentRank: 'Commander', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
      { personId: 2, name: 'Buzz Aldrin', currentRank: 'Lunar Module Pilot', currentDutyTitle: 'Apollo 11', careerStartDate: new Date('1966-03-16'), careerEndDate: new Date('1969-07-24') },
      { personId: 3, name: 'Sally Ride', currentRank: 'Mission Specialist', currentDutyTitle: 'STS-7', careerStartDate: new Date('1978-01-16'), careerEndDate: new Date('1987-08-15') },
    ];
  }
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
