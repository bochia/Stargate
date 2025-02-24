using Microsoft.AspNetCore.Mvc;

namespace Stargate.Server.Controllers
{
    public static class ControllerBaseExtensions
    {
        // ochia - maybe call this something else like FormatResponse or something like that.
        public static IActionResult GetResponse(this ControllerBase controllerBase, BaseResponse response)
        {
            var httpResponse = new ObjectResult(response);
            httpResponse.StatusCode = response.ResponseCode;
            return httpResponse;
        }
    }
}
