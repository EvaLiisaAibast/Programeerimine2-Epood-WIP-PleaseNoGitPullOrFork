using FluentValidation;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class SaveReviewResponseCommandValidator : AbstractValidator<SaveReviewResponseCommand>
    {
        public SaveReviewResponseCommandValidator()
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

            RuleFor(x => x.Data.EmployeeId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("EmployeeId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content on kohustuslik.")
                .MaximumLength(4000).WithMessage("Content võib olla kuni 4000 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
