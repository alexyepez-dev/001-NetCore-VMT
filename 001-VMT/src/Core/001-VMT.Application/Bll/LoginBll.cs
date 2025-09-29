using _001_VMT.Application.Contracts;
using _001_VMT.Application.Dtos;
using _001_VMT.Persistence.Database.Connection;
using _001_VMT.Shared.Contracts.Security.Access;
using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Helpers.Models;
using _001_VMT.Shared.Helpers.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace _001_VMT.Application.Bll;

public class LoginBll
(
    AppDbConnection _connection,
    IMapper _mapper,
    IAccessToken _access,
    IOptions<JwtSettings> _settings
) : ILoginBll
{
    private readonly AppDbConnection connection = _connection;
    private readonly IMapper mapper = _mapper;
    private readonly IAccessToken access = _access;
    private readonly JwtSettings settings = _settings.Value;

    public async Task<ApiResponse<AuthResponse>> Execute(LoginDto dto)
    {
        try
        {
            var loginBadRequest = SharedMessage.BadRequestGeneral;
            var loginSuccess = SharedMessage.LoginSuccess;
            var loginFailed = SharedMessage.InvalidCredentials;

            if (connection is null)
            {
                return ApiResult.BadRequest<AuthResponse>(loginBadRequest);
            }

            var user = await connection.Usuario.FirstOrDefaultAsync();
            var emailExists = user?.Email != dto.Email;
            var passwordExists = user?.Password != dto.Password;

            if (emailExists || passwordExists)
            {
                return ApiResult.BadRequest<AuthResponse>(loginFailed);
            }

            var token = access.GenerateToken(user!);
            var expiration = DateTime.UtcNow.AddYears(settings.Expiration);

            var authenticatedUser = new AuthResponse
            {
                Token = token,
                Expiration = expiration
            };

            return ApiResult.Ok
            (
                authenticatedUser,
                loginSuccess
            );
        }
        catch (Exception error)
        {
            var loginInternalError = SharedMessage.InternalErrorGeneral;

            return ApiResult.InternalError<AuthResponse>
            (
                loginInternalError,
                error
            );
        }
    }
}