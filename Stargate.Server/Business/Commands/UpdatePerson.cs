namespace Stargate.Server.Business.Commands
{
    using MediatR;
    using MediatR.Pipeline;
    using Microsoft.EntityFrameworkCore;
    using Stargate.Server.Controllers;
    using Stargate.Server.Data;
    using Stargate.Server.Data.Models;
    using System.Net;

    public class UpdatePersonRequest : IRequest<UpdatePersonResult>
    {
        public required string CurrentName { get; set; } = string.Empty;
        public required string NewName { get; set; } = string.Empty;
    }

    public class UpdatePersonResult : BaseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }

    public class UpdatePersonPreProcessor : IRequestPreProcessor<UpdatePersonRequest>
    {
        private readonly StargateContext _context;
        public UpdatePersonPreProcessor(StargateContext context)
        {
            _context = context;
        }

        public Task Process(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            // ochia - do I want to do anything here?

            return Task.CompletedTask;
        }
    }

    public class UpdatePersonHandler : IRequestHandler<UpdatePersonRequest, UpdatePersonResult>
    {
        private readonly StargateContext _context;

        public UpdatePersonHandler(StargateContext context)
        {
            _context = context;
        }

        public async Task<UpdatePersonResult> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
        {
            var existingPerson = await _context.People.Where(x => x.Name == request.CurrentName).FirstOrDefaultAsync();

            if (existingPerson == null)
            {
                // ochia - is this the correct way to get the correct response to the user?
                return new UpdatePersonResult()
                {
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.NotFound,
                    Message = $"Person with the name '{request.CurrentName}' not found."
                };
            }

            existingPerson.Name = request.NewName;

            await _context.SaveChangesAsync();

            return new UpdatePersonResult()
            {
                Id = existingPerson.Id,
                Name = existingPerson.Name
            };
        }
    }
}
