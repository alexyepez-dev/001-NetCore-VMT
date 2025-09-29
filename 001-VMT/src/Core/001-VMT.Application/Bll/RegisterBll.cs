using _001_VMT.Application.Contracts;
using _001_VMT.Application.Dtos;
using _001_VMT.Domain.Entities;
using _001_VMT.Persistence.Database.Connection;
using _001_VMT.Shared.Helpers.Message;
using _001_VMT.Shared.Helpers.Models;
using _001_VMT.Shared.Helpers.Results;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _001_VMT.Application.Bll;

public class RegisterBll
(
    AppDbConnection _connection,
    IMapper _mapper
) : IRegisterBll
{
    private readonly AppDbConnection connection = _connection;
    private readonly IMapper mapper = _mapper;

    public async Task<ApiResponse<RegisterDto>> Execute(RegisterDto dto)
    {
        try
        {
            var registerBadRequest = SharedMessage.BadRequestGeneral;
            var registerSuccess = SharedMessage.RegisterSuccess;
            var registerFailed = SharedMessage.InvalidCredentials;

            if (connection is null)
            {
                return ApiResult.BadRequest<RegisterDto>(registerBadRequest);
            }

            var usernameAlreadyExists = await connection.Usuario.AnyAsync(x => x.Username == dto.Username);
            var emailAlreadyExists = await connection.Usuario.AnyAsync(x => x.Email == dto.Email);
            var passwordAlreadyExists = await connection.Usuario.AnyAsync(x => x.Password == dto.Password);

            if (usernameAlreadyExists || emailAlreadyExists || passwordAlreadyExists)
            {
                return ApiResult.BadRequest<RegisterDto>(registerFailed);
            }

            var user = mapper.Map<User>(dto);

            await connection.AddAsync(user);
            await connection.SaveChangesAsync();

            return ApiResult.Ok
            (
                dto,
                registerSuccess
            );
        }
        catch (Exception error)
        {
            var registerInternalError = SharedMessage.InternalErrorGeneral;

            return ApiResult.InternalError<RegisterDto>
            (
                registerInternalError,
                error
            );
        }
    }
}