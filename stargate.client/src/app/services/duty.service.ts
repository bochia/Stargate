import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetAstronautDutiesResponse } from '../models/GetAstronautDutiesResponse';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DutyService {

  constructor(private httpClient: HttpClient) { }

  getAstronautDutiesByName(name: string): Observable<GetAstronautDutiesResponse> {
    // ochia - should have defensive coding here.
    return this.httpClient.get<GetAstronautDutiesResponse>(`/astronautduty/${name}`)
  }
}
