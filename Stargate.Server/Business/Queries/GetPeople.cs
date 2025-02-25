using MediatR;
using Stargate.Server.Controllers;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Microsoft.EntityFrameworkCore;
using Stargate.Server.Business.Extensions;

namespace Stargate.Server.Business.Queries
{
    public class GetPeopleRequest : IRequest<GetPeopleResult>
    {
        /*
         * ochia - in the future I would pass PageNumber and PageSize so that I could do pagination.
         * var skip = (pageNumber - 1) * pageSize;
         * var people = await _context.People.Skip(skip).Take(pageSize).ToListAsync();
         */
    }

    public class GetPeopleResult : BaseResponse
    {
        /*
         * ochia - If we need more information we could use PersonAstronaughtDto. 
         * But typically get all requires less data. Can use name from getall to do a get single.
         */
        public List<PersonAstronautDto> People { get; set; } = new List<PersonAstronautDto> { };

    }

    public class GetPeopleHandler : IRequestHandler<GetPeopleRequest, GetPeopleResult>
    {
        public readonly StargateContext _context;
        public GetPeopleHandler(StargateContext context)
        {
            _context = context;
        }
        public async Task<GetPeopleResult> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
        {
            var result = new GetPeopleResult();

            List<Person>? people = await _context.People.Include(x => x.AstronautDetail).ToListAsync();

            if (people == null || !people.Any())
            {
                return result;
            }

            result.People = people.ConvertToDto();

            return result;
        }
    }
}
