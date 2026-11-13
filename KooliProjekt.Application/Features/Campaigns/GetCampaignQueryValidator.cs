using FluentValidation;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class GetCampaignQueryValidator : AbstractValidator<GetCampaignQuery>
    {
        public GetCampaignQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
