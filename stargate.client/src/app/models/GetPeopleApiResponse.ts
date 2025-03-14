import { BaseResponse } from "./BaseResponse";
import { PersonAstronautDto } from "./PersonAstronautDto";

// ochia - instead of doing this I would normally make a generic class. Just running out of time at the moment.
export class GetPeopleApiResponse extends BaseResponse { 
  people: PersonAstronautDto[] | null = null;
}
