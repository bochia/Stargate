export interface AstronautDutyDto {
  id: number;
  personId: number;
  rank: string;
  dutyTitle: string;
  dutyStartDate: Date;
  dutyEndDate?: Date | null;
}
