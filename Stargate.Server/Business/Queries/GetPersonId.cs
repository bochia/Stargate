using MediatR;
using Stargate.Server.Controllers;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Microsoft.EntityFrameworkCore;
using Stargate.Server.Business.Extensions;

namespace Stargate.Server.Business.Queries
{
    public class GetPersonByIdRequest : IRequest<GetPersonByIdResult>
    {
        public int Id { get; set; }
    }

    public class GetPersonByIdResult : BaseResponse
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

    public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdRequest, GetPersonByIdResult>
    {
        private readonly StargateContext _context;
        public GetPersonByIdHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<GetPersonByIdResult> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var result = new GetPersonByIdResult();

            Person? person = await _context.People.Include(x => x.AstronautDetail)
                                                  .Where(x => x.Id == request.Id)
                                                  .FirstOrDefaultAsync();
            if (person == null)
            {
                return null;
            }

            result.Person = person.ConvertToDto();

            return result;
        }
    }
}
