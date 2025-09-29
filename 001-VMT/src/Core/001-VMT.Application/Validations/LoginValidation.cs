using _001_VMT.Application.Dtos;
using FluentValidation;

namespace _001_VMT.Application.Validations;

public class LoginValidation : AbstractValidator<LoginDto>
{
    public LoginValidation()
    {
        RuleFor(x => x.Email)
        .NotNull()
        .WithMessage("El campo no puede ser nulo")
        .NotEmpty()
        .WithMessage("El campo no puede estar vacio")
        .MaximumLength(50)
        .WithMessage("Solo se pueden maximo 50 caracteres");

        RuleFor(x => x.Password)
        .NotNull()
        .WithMessage("El campo no puede ser nulo")
        .NotEmpty()
        .WithMessage("El campo no puede estar vacio")
        .MaximumLength(50)
        .WithMessage("Solo se pueden maximo 50 caracteres");
    }
}