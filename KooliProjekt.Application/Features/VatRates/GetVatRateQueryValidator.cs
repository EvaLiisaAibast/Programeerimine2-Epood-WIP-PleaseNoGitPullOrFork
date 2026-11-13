using FluentValidation;

namespace KooliProjekt.Application.Features.VatRates
{
    public class GetVatRateQueryValidator : AbstractValidator<GetVatRateQuery>
    {
        public GetVatRateQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
