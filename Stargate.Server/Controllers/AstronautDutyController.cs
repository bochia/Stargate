using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stargate.Server.Business.Commands;
using Stargate.Server.Business.Queries;
using System.Net;

namespace Stargate.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AstronautDutyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AstronautDutyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ochia - If I had more time I would change this to go off of the ID of the person.
        [HttpGet("{personName}")]
        public async Task<IActionResult> GetAstronautDutiesByName(string personName)
        {
            try
            {
                var result = await _mediator.Send(new GetAstronautDutiesByNameRequest()
                {
                    Name = personName
                });

                return this.GetResponse(result);
            }
            catch (Exception ex)
            {
                return this.GetResponse(new BaseResponse()
                {
                    Message = ex.Message,
                    Success = false,
                    ResponseCode = (int)HttpStatusCode.InternalServerError
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAstronautDuty([FromBody] CreateAstronautDutyRequest request)
        {
            var result = await _mediator.Send(request);
            return this.GetResponse(result);
        }
    }
}
