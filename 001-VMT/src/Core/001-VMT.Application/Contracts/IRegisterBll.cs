using _001_VMT.Application.Dtos;
using _001_VMT.Shared.Helpers.Models;

namespace _001_VMT.Application.Contracts;

public interface IRegisterBll
{
    Task<ApiResponse<RegisterDto>> Execute(RegisterDto dto);
}