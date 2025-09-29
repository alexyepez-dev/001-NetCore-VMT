using _001_VMT.Application.Contracts;
using _001_VMT.Application.Dtos;
using _001_VMT.Shared.ExceptionFilter;
using _001_VMT.Shared.Helpers.Models;
using _001_VMT.Shared.Helpers.Results;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace _001_VMT.Api.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    [TypeFilter(typeof(ExceptionManager))]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponse>>> Login
        (
            [FromBody] LoginDto dto,
            [FromServices] ILoginBll bll,
            [FromServices] IValidator<LoginDto> validator
        )
        {
            var validate = await validator.ValidateAsync(dto);

            if (!validate.IsValid)
            {
                var errors = validate.Errors;

                return BadRequest(errors);
            }

            var result = await bll.Execute(dto);

            return GetResultEndpoint.Response(result, this);
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<RegisterDto>>> Register
        (
            [FromBody] RegisterDto dto,
            [FromServices] IRegisterBll bll,
            [FromServices] IValidator<RegisterDto> validator
        )
        {
            var validate = await validator.ValidateAsync(dto);

            if (!validate.IsValid)
            {
                var errors = validate.Errors;

                return BadRequest(errors);
            }

            var result = await bll.Execute(dto);

            return GetResultEndpoint.Response(result, this);
        }
    }
}