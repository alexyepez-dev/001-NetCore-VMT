using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace _001_VMT.Shared.Helpers.Results;

public static class GetResultEndpoint
{
    public static ActionResult Response<T>(ApiResponse<T> response, ControllerBase controller)
    {
        var successfulOperation = response.Success;
        if (successfulOperation)
        {
            var result = controller.Ok(response);
            return result;
        }

        var notFound = controller.NotFound(response);
        var internalError = controller.StatusCode(500, response);
        var badRequest = controller.BadRequest(response);
        var unauthorized = controller.Unauthorized(response);
 
        return response.StatusCode switch
        {
            SharedMessage.NotFound => notFound,
            SharedMessage.InternalError => internalError,
            SharedMessage.Unauthorized => unauthorized,
            _ => badRequest
        };
    }
}