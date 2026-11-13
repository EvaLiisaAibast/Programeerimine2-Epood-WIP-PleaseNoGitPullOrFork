using FluentValidation;

namespace KooliProjekt.Application.Features.WishlistItems
{
    public class SaveWishlistItemCommandValidator : AbstractValidator<SaveWishlistItemCommand>
    {
        public SaveWishlistItemCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.WishlistId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("WishlistId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.VariantId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("VariantId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);
        }
    }
}
