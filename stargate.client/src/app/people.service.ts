import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetPersonApiResponse } from './models/GetPersonApiResponse';
import { PersonAstronautDto } from './models/PersonAstronautDto';

@Injectable({
  providedIn: 'root'
})
export class PeopleService {

  constructor(private httpClient: HttpClient) { }

  getPeople(name: string): Observable<GetPersonApiResponse> {
    return this.httpClient.get<GetPersonApiResponse>(`/person`);
  }

  getPerson(name: string): Observable<GetPersonApiResponse> {
    // ochia - should put defensive code here.
    return this.httpClient.get<GetPersonApiResponse>(`/person/${name}`);
  }
}
