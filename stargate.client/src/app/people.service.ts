import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GetPersonApiResponse } from './models/GetPersonApiResponse';
import { GetPeopleApiResponse } from './models/GetPeopleApiResponse';

@Injectable({
  providedIn: 'root'
})

// ochia - would like to make a folder for services.
export class PeopleService {

  constructor(private httpClient: HttpClient) { }

  getPeople(): Observable<GetPeopleApiResponse> {
    return this.httpClient.get<GetPeopleApiResponse>(`/person`);
  }

  getPerson(name: string): Observable<GetPersonApiResponse> {
    // ochia - should put defensive code here.
    return this.httpClient.get<GetPersonApiResponse>(`/person/${name}`);
  }
}
