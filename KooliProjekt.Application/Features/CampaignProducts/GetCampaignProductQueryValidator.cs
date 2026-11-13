using FluentValidation;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class GetCampaignProductQueryValidator : AbstractValidator<GetCampaignProductQuery>
    {
        public GetCampaignProductQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
