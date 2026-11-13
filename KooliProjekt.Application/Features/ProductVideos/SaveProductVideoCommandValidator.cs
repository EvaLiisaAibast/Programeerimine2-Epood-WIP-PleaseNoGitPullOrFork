using FluentValidation;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class SaveProductVideoCommandValidator : AbstractValidator<SaveProductVideoCommand>
    {
        public SaveProductVideoCommandValidator()
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

            RuleFor(x => x.Data.Url)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Url on kohustuslik.")
                .MaximumLength(255).WithMessage("Url võib olla kuni 255 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Title)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(200).WithMessage("Title võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
