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
    public class GetAstronautDutiesByNameRequest : IRequest<GetAstronautDutiesByNameResult>
    {
        public string Name { get; set; } = string.Empty;
    }

    public class GetAstronautDutiesByNameResult : BaseResponse
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

    public class GetAstronautDutiesByNameHandler : IRequestHandler<GetAstronautDutiesByNameRequest, GetAstronautDutiesByNameResult>
    {
        private readonly StargateContext _context;

        public GetAstronautDutiesByNameHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetAstronautDutiesByNameResult> Handle(GetAstronautDutiesByNameRequest request, CancellationToken cancellationToken)
        {

            var result = new GetAstronautDutiesByNameResult();

            Person? person = await _context.People.Include(x => x.AstronautDetail)
                                                  .Include(x => x.AstronautDuties)
                                                  .Where(x => x.Name == request.Name)
                                                  .FirstOrDefaultAsync();

            if (person == null) 
            {
                return new GetAstronautDutiesByNameResult()
                {
                    Success = false,
                    Message = $"Person with name '{request.Name}' was not found.",
                    ResponseCode = (int)HttpStatusCode.NotFound
                };
            }

            result.AstronautDuties = person.AstronautDuties.ConvertToDto();

            return result;
        }
    }
}
