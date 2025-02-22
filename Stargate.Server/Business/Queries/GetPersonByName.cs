using MediatR;
using Stargate.Server.Controllers;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Microsoft.EntityFrameworkCore;
using Stargate.Server.Business.Extensions;

namespace Stargate.Server.Business.Queries
{
    public class GetPersonByName : IRequest<GetPersonByNameResult>
    {
        public required string Name { get; set; } = string.Empty;
    }

    public class GetPersonByNameHandler : IRequestHandler<GetPersonByName, GetPersonByNameResult>
    {
        private readonly StargateContext _context;
        public GetPersonByNameHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetPersonByNameResult> Handle(GetPersonByName request, CancellationToken cancellationToken)
        {
            var result = new GetPersonByNameResult();

            Person? person = await _context.People.Include(x => x.AstronautDetail)
                                                  .Where(x => x.Name == request.Name)
                                                  .FirstOrDefaultAsync();
            if (person == null)
            {
                return null;
            }

            result.Person = person.ConvertToDto();

            return result;
        }
    }

    public class GetPersonByNameResult : BaseResponse
    {
        public PersonAstronautDto? Person { get; set; }
    }

    public class PersonAstronautDto
    {
        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? CurrentRank { get; set; } = string.Empty;

        public string? CurrentDutyTitle { get; set; } = string.Empty;

        public DateTime? CareerStartDate { get; set; }

        public DateTime? CareerEndDate { get; set; }
    }
}
