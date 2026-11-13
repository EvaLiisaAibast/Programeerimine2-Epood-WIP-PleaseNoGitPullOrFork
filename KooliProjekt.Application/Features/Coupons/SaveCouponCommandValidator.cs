using FluentValidation;

namespace KooliProjekt.Application.Features.Coupons
{
    public class SaveCouponCommandValidator : AbstractValidator<SaveCouponCommand>
    {
        public SaveCouponCommandValidator()
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

            RuleFor(x => x.Data.Code)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Code on kohustuslik.")
                .MaximumLength(50).WithMessage("Code võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.UsageLimit)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("UsageLimit ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.UsedCount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("UsedCount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.MinimumOrderAmount)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("MinimumOrderAmount ei tohi olla väiksem kui 0.")
                .When(x => x.Data != null);
        }
    }
}
