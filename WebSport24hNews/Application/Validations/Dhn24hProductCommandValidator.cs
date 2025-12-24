using FluentValidation;
using WebSport24hNews.Application.Command.Modell._24hProduct;

namespace WebSport24hNews.Application.Validations
{
    public class Dhn24hProductCommandValidator : AbstractValidator<DhnProductCommand>
    {
        public Dhn24hProductCommandValidator()
        {
            RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Tên sản phẩm là bắt buộc.")
            .MaximumLength(255).WithMessage("Tên sản phẩm không được vượt quá 255 ký tự.");

            RuleFor(x => x.CategoryId)
                .NotNull().WithMessage("Danh mục là bắt buộc.")
                .GreaterThan(0).WithMessage("Danh mục không hợp lệ.");

            RuleFor(x => x.OriginalPrice)
                .NotNull().WithMessage("Giá gốc là bắt buộc.")
                .GreaterThanOrEqualTo(0).WithMessage("Giá gốc phải >= 0.");

            RuleFor(x => x.CurrentPrice)
                .NotNull().WithMessage("Giá hiện tại là bắt buộc.")
                .GreaterThanOrEqualTo(0).WithMessage("Giá hiện tại phải >= 0.");

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Thương hiệu là bắt buộc.")
                .MaximumLength(100).WithMessage("Thương hiệu không được vượt quá 100 ký tự.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Mô tả là bắt buộc.");

            RuleFor(x => x.StockQuantity)
                .NotNull().WithMessage("Tồn kho là bắt buộc.")
                .GreaterThanOrEqualTo(0).WithMessage("Số lượng tồn kho phải >= 0.");

            RuleFor(x => x.IsBestSeller)
                .NotEmpty().WithMessage("Trường IsBestSeller là bắt buộc.")
                .Must(v => v == "Y" || v == "N")
                .WithMessage("IsBestSeller chỉ nhận giá trị 'Y' hoặc 'N'.");
        }
    }
}
