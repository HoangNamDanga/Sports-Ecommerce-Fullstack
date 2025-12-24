using FluentValidation;
using WebSport24hNews.Application.Command.Modell._24hNewsArticlesSport;

namespace WebSport24hNews.Application.Validations
{
    public class ArticlesSportCommandValidator : AbstractValidator<DhnArticlesSportCommand>
    {
        public ArticlesSportCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Tiêu đề không được để trống.")
                .MaximumLength(255).WithMessage("Tiêu đề không được vượt quá 255 ký tự.");

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Nội dung không được để trống.");

            RuleFor(x => x.ImageUrl)
                .MaximumLength(255).WithMessage("Đường dẫn ảnh không được vượt quá 255 ký tự.")
                .When(x => !string.IsNullOrEmpty(x.ImageUrl));

            RuleFor(x => x.PublishedDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Ngày đăng không được lớn hơn ngày hiện tại.")
                .When(x => x.PublishedDate.HasValue);

            RuleFor(x => x.Author)
                .MaximumLength(100).WithMessage("Tên tác giả không được vượt quá 100 ký tự.")
                .When(x => !string.IsNullOrEmpty(x.Author));
        }
    }
}
