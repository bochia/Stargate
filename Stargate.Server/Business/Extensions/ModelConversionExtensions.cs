namespace Stargate.Server.Business.Extensions
{
    using Stargate.Server.Business.Queries;
    using Stargate.Server.Data.Models;

    // ochia - would normally use automapper for doing conversions, but dont want to mess with it for this.
    public static class ModelConversionExtensions
    {

        public static PersonAstronautDto ConvertToDto(this Person person)
        {
            // ochia - need to put defensive coding here for null AstronautDetail. What should happen?
            var personAstronautDto = new PersonAstronautDto()
            {
                PersonId = person.Id,
                Name = person.Name,
            };

            if (person.AstronautDetail != null)
            {
                personAstronautDto.CurrentRank = person.AstronautDetail.CurrentRank;
                personAstronautDto.CurrentDutyTitle = person.AstronautDetail.CurrentDutyTitle;
                personAstronautDto.CareerStartDate = person.AstronautDetail.CareerStartDate;
                personAstronautDto.CareerEndDate = person.AstronautDetail.CareerEndDate;
            }

            return personAstronautDto;
        }
    }
}
