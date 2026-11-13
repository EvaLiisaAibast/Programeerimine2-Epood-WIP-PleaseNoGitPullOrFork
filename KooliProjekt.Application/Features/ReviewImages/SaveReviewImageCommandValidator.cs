using FluentValidation;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class SaveReviewImageCommandValidator : AbstractValidator<SaveReviewImageCommand>
    {
        public SaveReviewImageCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ReviewId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ReviewId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Url)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Url on kohustuslik.")
                .MaximumLength(255).WithMessage("Url võib olla kuni 255 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
