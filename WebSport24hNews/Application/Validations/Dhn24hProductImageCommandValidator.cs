using FluentValidation;
using WebSport24hNews.Application.Command.Handlerr._24hProductImage;

namespace WebSport24hNews.Application.Validations
{
    public class Dhn24hProductImageCommandValidator : AbstractValidator<DhnProductImageCommand>
    {
        public Dhn24hProductImageCommandValidator()
        {
            RuleFor(x => x.ProductId)
                       .NotNull().WithMessage("ProductId là bắt buộc.")
                       .GreaterThan(0).WithMessage("ProductId phải lớn hơn 0.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl là bắt buộc.")
                .MaximumLength(255).WithMessage("ImageUrl không được vượt quá 255 ký tự.");

            RuleFor(x => x.IsThumbnail)
                .NotEmpty().WithMessage("IsThumbnail là bắt buộc.")
                .Must(v => v == "Y" || v == "N")
                .WithMessage("IsThumbnail chỉ nhận 'Y' hoặc 'N'.");

            RuleFor(x => x.DisplayOrder)
                .NotNull().WithMessage("DisplayOrder là bắt buộc.")
                .GreaterThanOrEqualTo(0).WithMessage("DisplayOrder phải >= 0.");

            RuleFor(x => x.AltText)
                .NotEmpty().WithMessage("AltText là bắt buộc.")
                .MaximumLength(255).WithMessage("AltText không được vượt quá 255 ký tự.");
        }
    }
}
