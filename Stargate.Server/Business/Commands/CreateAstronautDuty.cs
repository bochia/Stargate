using MediatR.Pipeline;
using MediatR;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Stargate.Server.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System;

namespace Stargate.Server.Business.Commands
{
    public class CreateAstronautDutyRequest : IRequest<CreateAstronautDutyResult>
    {
        public required string Name { get; set; }

        public required string Rank { get; set; }

        public required string DutyTitle { get; set; }

        public DateTime DutyStartDate { get; set; }
    }

    public class CreateAstronautDutyResult : BaseResponse
    {
        public int? Id { get; set; }
    }

    public class CreateAstronautDutyPreProcessor : IRequestPreProcessor<CreateAstronautDutyRequest>
    {
        private readonly StargateContext _context;

        public CreateAstronautDutyPreProcessor(StargateContext context)
        {
            _context = context;
        }

        public Task Process(CreateAstronautDutyRequest request, CancellationToken cancellationToken)
        {
            var person = _context.People.AsNoTracking().FirstOrDefault(z => z.Name == request.Name);

            if (person is null) throw new BadHttpRequestException("Bad Request");

            var verifyNoPreviousDuty = _context.AstronautDuties.FirstOrDefault(z => z.DutyTitle == request.DutyTitle && z.DutyStartDate == request.DutyStartDate);

            if (verifyNoPreviousDuty is not null) throw new BadHttpRequestException("Bad Request");

            return Task.CompletedTask;
        }
    }

    public class CreateAstronautDutyHandler : IRequestHandler<CreateAstronautDutyRequest, CreateAstronautDutyResult>
    {
        private readonly StargateContext _context;
        private const string RetiredDutyTitle = "RETIRED";

        public CreateAstronautDutyHandler(StargateContext context)
        {
            _context = context;
        }
        public async Task<CreateAstronautDutyResult> Handle(CreateAstronautDutyRequest request, CancellationToken cancellationToken)
        {

            Person? person = await _context.People.Include(x => x.AstronautDetail)
                                                  .Include(x => x.AstronautDuties)
                                                  .Where(x => x.Name == request.Name)
                                                  .FirstOrDefaultAsync();
            if (person == null)
            {
                return new CreateAstronautDutyResult()
                {
                    Success = false,
                    Message = $"Person with name '{request.Name}' was not found.'",
                    ResponseCode = (int)HttpStatusCode.NotFound
                };
            }

            await UpdateCurrentAstronautDetail(person, request);
            await GiveTheMostRecentDutyAnEndDate(person, request);
            int newDutyId = await AddTheNewDuty(person, request);

            return new CreateAstronautDutyResult()
            {
                Id = newDutyId
            };
        }

        /**
         * Update the persons current astronaut detail to be the new duty that we are adding.
         */
        private async Task UpdateCurrentAstronautDetail(Person person, CreateAstronautDutyRequest request)
        {
            if(person.AstronautDetail == null)
            {
                var astronautDetail = new AstronautDetail();
                astronautDetail.PersonId = person.Id;
                astronautDetail.CurrentDutyTitle = request.DutyTitle;
                astronautDetail.CurrentRank = request.Rank;
                astronautDetail.CareerStartDate = request.DutyStartDate.Date;

                if (request.DutyTitle == RetiredDutyTitle)
                {
                    astronautDetail.CareerEndDate = request.DutyStartDate.Date;
                }

                await _context.AstronautDetails.AddAsync(astronautDetail);

            }
            else
            {
                person.AstronautDetail.CurrentDutyTitle = request.DutyTitle;
                person.AstronautDetail.CurrentRank = request.Rank;

                if (request.DutyTitle == RetiredDutyTitle)
                {
                    // A Person's Career End Date is one day before the Retired Duty Start Date.
                    person.AstronautDetail.CareerEndDate = request.DutyStartDate.AddDays(-1).Date;
                }
            }
        }

        private async Task GiveTheMostRecentDutyAnEndDate(Person person, CreateAstronautDutyRequest request)
        {
            var astronautDuty = person.AstronautDuties.OrderByDescending(x => x.DutyStartDate).FirstOrDefault();

            if (astronautDuty != null)
            {
                // A Person's Previous Duty End Date is set to the day before the New Astronaut Duty Start Date when a new Astronaut Duty is received for a Person.
                astronautDuty.DutyEndDate = request.DutyStartDate.AddDays(-1).Date;
                _context.AstronautDuties.Update(astronautDuty);
            }
        }

        private async Task<int> AddTheNewDuty(Person person, CreateAstronautDutyRequest request)
        {
            var newAstronautDuty = new AstronautDuty()
            {
                PersonId = person.Id,
                Rank = request.Rank,
                DutyTitle = request.DutyTitle,
                DutyStartDate = request.DutyStartDate.Date,
                DutyEndDate = null
            };

            await _context.AstronautDuties.AddAsync(newAstronautDuty);

            await _context.SaveChangesAsync();

            return newAstronautDuty.Id;
        }
    }
}
