using _001_VMT.Application.Dtos;
using _001_VMT.Shared.Helpers.Models;

namespace _001_VMT.Application.Contracts;

public interface ILoginBll
{
    Task<ApiResponse<AuthResponse>> Execute(LoginDto dto);
}