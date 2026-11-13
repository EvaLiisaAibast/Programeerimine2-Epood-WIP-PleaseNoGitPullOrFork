using FluentValidation;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class SaveCampaignProductCommandValidator : AbstractValidator<SaveCampaignProductCommand>
    {
        public SaveCampaignProductCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CampaignId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CampaignId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ProductId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ProductId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.DiscountPercent)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(0, 100).WithMessage("DiscountPercent peab olema vahemikus 0 kuni 100.")
                .When(x => x.Data != null);
        }
    }
}
