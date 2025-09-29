using _001_VMT.Application.Dtos;
using FluentValidation;

namespace _001_VMT.Application.Validations;

public class RegisterValidation : AbstractValidator<RegisterDto>
{
    public RegisterValidation()
    {
        RuleFor(x => x.Username)
        .NotNull()
        .WithMessage("El campo no puede ser nulo")
        .NotEmpty()
        .WithMessage("El campo no puede estar vacio")
        .MinimumLength(3)
        .WithMessage("Solo se pueden minimo 3 caracteres")
        .MaximumLength(20)
        .WithMessage("Solo se pueden maximo 20 caracteres");

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

        RuleFor(x => x.CompanyName)
        .NotNull()
        .WithMessage("El campo no puede ser nulo")
        .NotEmpty()
        .WithMessage("El campo no puede estar vacio")
        .MaximumLength(30)
        .WithMessage("Solo se pueden maximo 30 caracteres");
    }
}