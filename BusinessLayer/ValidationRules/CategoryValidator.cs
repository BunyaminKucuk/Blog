using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategoryi adını boş geçemezsiniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategoryi adı en fazla 50 karakter içermelidir");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategoryi adı en az 2 karakter içermelidir");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategoryi açıklamaısnı boş geçemezsiniz");
        }
    }
}
