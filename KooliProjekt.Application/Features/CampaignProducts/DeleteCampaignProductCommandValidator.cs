using FluentValidation;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class DeleteCampaignProductCommandValidator : AbstractValidator<DeleteCampaignProductCommand>
    {
        public DeleteCampaignProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
