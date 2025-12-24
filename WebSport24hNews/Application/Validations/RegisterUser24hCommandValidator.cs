using FluentValidation;
using WebSport24hNews.Application.Command.Modell.Account;

namespace WebSport24hNews.Application.Validations
{
    public class RegisterUser24hCommandValidator : AbstractValidator<RegisterUser24hCommand>
    {
        public RegisterUser24hCommandValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .Length(3, 15).WithMessage("Username must be between 3 and 15 characters.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(x => x.Fullname)
                .NotEmpty().WithMessage("Fullname is required.")
                .Length(3, 15).WithMessage("Fullname must be between 3 and 15 characters.");

            RuleFor(x => x.Phone)
                .MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Phone))
                .Matches(@"^\+?[0-9]{7,15}$").When(x => !string.IsNullOrEmpty(x.Phone))
                .WithMessage("Phone must be a valid phone number.");

            RuleFor(x => x.Role)
                .MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Role))
                .WithMessage("Role must not exceed 255 characters.");
        }
    }
}
