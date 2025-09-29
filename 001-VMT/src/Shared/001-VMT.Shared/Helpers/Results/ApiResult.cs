using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Helpers.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace _001_VMT.Shared.Helpers.Results;

public static class ApiResult
{
    public static ApiResponse<T> Ok<T>(T data, string message)
    {
        var success = true;
        var statusCode = SharedMessage.Ok;
        var statusText = SharedMessage.OkMessage;

        return new
        (
            success,
            statusCode,
            statusText,
            message,
            data
        );
    }

    public static ApiResponse<T> NotFound<T>(string message)
    {
        var success = false;
        var statusCode = SharedMessage.NotFound;
        var statusText = SharedMessage.NotFoundMessage;

        return new
        (
            success,
            statusCode,
            statusText,
            message,
            default!
        );
    }

    public static ApiResponse<T> BadRequest<T>(string message)
    {
        var success = false;
        var statusCode = SharedMessage.BadRequest;
        var statusText = SharedMessage.BadRequestMessage;

        return new
        (
            success,
            statusCode,
            statusText,
            message,
            default!
        );
    }

    public static ApiResponse<T> InternalError<T>(string message, Exception error)
    {
        var success = false;
        var statusCode = SharedMessage.InternalError;
        var statusText = SharedMessage.InternalErrorMessage;

        return new
        (
            success,
            statusCode,
            statusText,
            $"Error: {message} | Exception: {error.Message}",
            default!
        );
    }

    public static ApiResponse<T> InternalError<T>(string message, ExceptionContext context)
    {
        var success = false;
        var statusCode = SharedMessage.InternalError;
        var statusText = SharedMessage.InternalErrorMessage;

        return new
        (
            success,
            statusCode,
            statusText,
            $"Error: {message} | Exception: {context.Exception.Message}",
            default!
        );
    }
}