using FluentValidation;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class SaveCampaignCommandValidator : AbstractValidator<SaveCampaignCommand>
    {
        public SaveCampaignCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
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

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
