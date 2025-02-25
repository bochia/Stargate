using MediatR.Pipeline;
using MediatR;
using Stargate.Server.Controllers;
using Stargate.Server.Data.Models;
using Stargate.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Stargate.Server.Business.Commands
{
    public class CreatePersonRequest : IRequest<CreatePersonResult>
    {
        public required string Name { get; set; } = string.Empty;
    }

    public class CreatePersonResult : BaseResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CreatePersonPreProcessor : IRequestPreProcessor<CreatePersonRequest>
    {
        private readonly StargateContext _context;
        public CreatePersonPreProcessor(StargateContext context)
        {
            _context = context;
        }
        public Task Process(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var person = _context.People.AsNoTracking().FirstOrDefault(z => z.Name == request.Name); 

            if (person is not null) throw new BadHttpRequestException("Bad Request");

            return Task.CompletedTask;
        }
    }

    public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, CreatePersonResult>
    {
        private readonly StargateContext _context;

        public CreatePersonHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<CreatePersonResult> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
        {
            var existingPerson = await _context.People.Where(x => x.Name == request.Name).FirstOrDefaultAsync();

            if (existingPerson != null)
            {
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
                Id = newPerson.Id,
                Name = newPerson.Name
            };
        }
    }
}
