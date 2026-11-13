using FluentValidation;

namespace KooliProjekt.Application.Features.Reviews
{
    public class SaveReviewCommandValidator : AbstractValidator<SaveReviewCommand>
    {
        public SaveReviewCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CustomerId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CustomerId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ProductId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.OrderLineId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("OrderLineId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Rating)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(1, 5).WithMessage("Rating peab olema vahemikus 1 kuni 5.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title on kohustuslik.")
                .MaximumLength(200).WithMessage("Title võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content on kohustuslik.")
                .MaximumLength(4000).WithMessage("Content võib olla kuni 4000 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
