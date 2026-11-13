using FluentValidation;

namespace KooliProjekt.Application.Features.Carriers
{
    public class GetCarrierQueryValidator : AbstractValidator<GetCarrierQuery>
    {
        public GetCarrierQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
