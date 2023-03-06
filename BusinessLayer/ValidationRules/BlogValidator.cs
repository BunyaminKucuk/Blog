using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha az giriş yapın");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az giriş yapın");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş geçilemez");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha az giriş yapın");
            RuleFor(x => x.BlogContent).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az giriş yapın");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog göreselini boş geçilemez");



        }

    }
}
