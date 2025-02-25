
import { AstronautDutyDto } from "./AstronautDutyDto";
import { BaseResponse } from "./BaseResponse";

// ochia - instead of doing this I would normally make a generic class. Just running out of time at the moment.
export class GetAstronautDutiesResponse extends BaseResponse {
  astronautDuties: AstronautDutyDto[] | null = null;
}
