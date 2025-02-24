using MediatR.Pipeline;
using MediatR;
using Stargate.Server.Controllers;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Stargate.Server.Business.Commands
{
    public class CreatePerson : IRequest<CreatePersonResult>
    {
        public required string Name { get; set; } = string.Empty;
    }

    public class CreatePersonPreProcessor : IRequestPreProcessor<CreatePerson>
    {
        private readonly StargateContext _context;
        public CreatePersonPreProcessor(StargateContext context)
        {
            _context = context;
        }
        public Task Process(CreatePerson request, CancellationToken cancellationToken)
        {
            var person = _context.People.AsNoTracking().FirstOrDefault(z => z.Name == request.Name);

            if (person is not null) throw new BadHttpRequestException("Bad Request");

            return Task.CompletedTask;
        }
    }

    public class CreatePersonHandler : IRequestHandler<CreatePerson, CreatePersonResult>
    {
        private readonly StargateContext _context;

        public CreatePersonHandler(StargateContext context)
        {
            _context = context;
        }

        /*
         * ochia - going with the solution to block adding duplicates. having duplicates makes retrieval a dilemma.
         * If names are not able to be unique, we aren't able to magically retrieve the correct person just on name alone.
         * The burder on providing uniqueness will need to fall on the external system, by one of the following options:
         * 1.) The external system may need to concatenate different data on their side into the name to make it unique. 
         * 2.) (Preferred) We could ask them to retrieve people by our internal ID, that we return after we create it by name. 
         */
        public async Task<CreatePersonResult> Handle(CreatePerson request, CancellationToken cancellationToken)
        {
            var existingPerson = await _context.People.Where(x => x.Name == request.Name).FirstOrDefaultAsync();

            if (existingPerson != null)
            {
                // ochia - is this the correct way to get the correct response to the user?
                return new CreatePersonResult()
                {
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.Conflict,
                    Message = $"Person with the name '{request.Name}' already exists."
                };
            }

            var newPerson = new Person()
            {
                Name = request.Name
            };

            await _context.People.AddAsync(newPerson);

            await _context.SaveChangesAsync();

            return new CreatePersonResult()
            {
                Id = newPerson.Id
            };
        }
    }

    public class CreatePersonResult : BaseResponse
    {
        public int Id { get; set; }
    }
}
