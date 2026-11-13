using FluentValidation;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class SaveProductVariantCommandValidator : AbstractValidator<SaveProductVariantCommand>
    {
        public SaveProductVariantCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ProductId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ProductCode on kohustuslik.")
                .MaximumLength(50).WithMessage("ProductCode võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Barcode)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(50).WithMessage("Barcode võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Price)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("Price ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.WeightKg)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("WeightKg ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
