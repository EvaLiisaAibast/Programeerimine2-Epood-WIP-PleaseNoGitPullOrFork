using FluentValidation;

namespace KooliProjekt.Application.Features.Products
{
    public class SaveProductCommandValidator : AbstractValidator<SaveProductCommand>
    {
        public SaveProductCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CategoryId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CategoryId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.BrandId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("BrandId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name on kohustuslik.")
                .MaximumLength(200).WithMessage("Name võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Description)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(2000).WithMessage("Description võib olla kuni 2000 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.BasePrice)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("BasePrice ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Price ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.WeightKg)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("WeightKg ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ImageUrl)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(255).WithMessage("ImageUrl võib olla kuni 255 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
