<!--v003-->
# Stargate

***

## Astronaut Career Tracking System (ACTS)

ACTS is used as a tool to maintain a record of all the People that have served as Astronauts. When serving as an Astronaut, your *Job* (Duty) is tracked by your Rank, Title and the Start and End Dates of the Duty.

The People that exist in this system are not all Astronauts. ACTS maintains a master list of People and Duties that are updated from an external service (not controlled by ACTS). The update schedule is determined by the external service.

## Definitions

1. A person's astronaut assignment is the Astronaut Duty.
1. A person's list of astronaut assignments is stored in the Astronaut Duty table.
1. A person's current astronaut information is stored in the Astronaut Detail table.

## Requirements

##### Enhance the Stargate API (Required)

The REST API is expected to do the following:

1. [X]Retrieve a person by name.
1. [X]Retrieve all people.
1. [x]Add/[X]update a person by name.

1. [X]Retrieve Astronaut Duty by name.
1. [X]Add an Astronaut Duty.

##### Implement a user interface: (Required)

The UI is expected to do the following:

1. Successfully run an Angular web application that demonstrates production level quality.
1. Implement call(s) to retrieve an individual's astronaut duties.
   [] Allow someone to see a list of People. 
   [] Allow for searching a list of people to find a single person.
1. Display the progress of the process and the results in a visually sophisticated and appealing manner.

## Tasks

Overview
Examine the code, find and resolve any flaws, if any exist. Identify design patterns and follow or change them. Provide fix(es) and be prepared to describe the changes.

1. Generate the database
   * This is your source and storage location
1. Enforce the rules
1. Improve defensive coding
1. Add unit tests
   * identify the most impactful methods requiring tests
   * reach >50% code coverage
1. Implement process logging
   * Log exceptions
   * Log successes
   * Store the logs in the database

## Rules

1. [X] A Person is uniquely identified by their Name.
1. [X] A Person who has not had an astronaut assignment will not have Astronaut records.
1. [X] A Person will only ever hold one current Astronaut Duty Title, Start Date, and Rank at a time.
1. [X] A Person's Current Duty will not have a Duty End Date.
1. [X] A Person's Previous Duty End Date is set to the day before the New Astronaut Duty Start Date when a new Astronaut Duty is received for a Person.
1. [X] A Person is classified as 'Retired' when a Duty Title is 'RETIRED'.
1. [X] A Person's Career End Date is one day before the Retired Duty Start Date.
[] ochia - career and duty end date are different. 
[] ochia - Will need logic for career start date as well. Implement in the getbyname endpoint for Person.