using MediatR;
using Stargate.Server.Controllers;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Stargate.Server.Business.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Stargate.Server.Business.Queries
{
    public class GetAstronautDutiesByPersonIdRequest : IRequest<GetAstronautDutiesByPersonIdResult>
    {
        public int PersonId { get; set; }
    }

    public class GetAstronautDutiesByPersonIdResult : BaseResponse
    {
        public List<AstronautDutyDto> AstronautDuties { get; set; } = new List<AstronautDutyDto>();
    }

    public class AstronautDutyDto
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Rank { get; set; } = string.Empty;

        public string DutyTitle { get; set; } = string.Empty;

        public DateTime DutyStartDate { get; set; }

        public DateTime? DutyEndDate { get; set; }

    }

    public class GetAstronautDutiesByPersonIdHandler : IRequestHandler<GetAstronautDutiesByPersonIdRequest, GetAstronautDutiesByPersonIdResult>
    {
        private readonly StargateContext _context;

        public GetAstronautDutiesByPersonIdHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetAstronautDutiesByPersonIdResult> Handle(GetAstronautDutiesByPersonIdRequest request, CancellationToken cancellationToken)
        {

            var result = new GetAstronautDutiesByPersonIdResult();

            Person? person = await _context.People.Include(x => x.AstronautDetail)
                                                  .Include(x => x.AstronautDuties)
                                                  .Where(x => x.Id == request.PersonId)
                                                  .FirstOrDefaultAsync();

            if (person == null) 
            {
                return new GetAstronautDutiesByPersonIdResult()
                {
                    Success = false,
                    Message = $"Person with Id '{request.PersonId}' was not found.",
                    ResponseCode = (int)HttpStatusCode.NotFound
                };
            }

            result.AstronautDuties = person.AstronautDuties.ConvertToDto();

            return result;
        }
    }
}
