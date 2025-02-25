using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stargate.Server.Business.Commands;
using Stargate.Server.Business.Queries;
using System.Net;

namespace Stargate.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly string BlankNameError = "Must pass a valid name, it cannot be blank.";
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            try
            {
                var result = await _mediator.Send(new GetPeopleRequest()
                {

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

        // ochia - If I had more time I would change this to go off of the ID of the person.
        [HttpGet("{name}")]
        public async Task<IActionResult> GetPersonByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(BlankNameError);
            }

            try
            {
                var result = await _mediator.Send(new GetPersonByNameRequest()
                {
                    Name = name
                });

                if (result == null)
                {
                    return NotFound();
                }

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
        public async Task<IActionResult> CreatePerson([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest(BlankNameError);
            }

            try
            {
                var result = await _mediator.Send(new CreatePersonRequest()
                {
                    Name = name
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

        [HttpPut]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonRequest updatePersonRequest)
        {
            if (updatePersonRequest == null)
            {
                return BadRequest("Request body cannot be null");
            }

            if (string.IsNullOrWhiteSpace(updatePersonRequest.CurrentName) || string.IsNullOrWhiteSpace(updatePersonRequest.NewName))
            {
                // ochia - improve this to be 
                return BadRequest(BlankNameError);
            }

            try
            {
                var result = await _mediator.Send(updatePersonRequest);

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
    }
}
