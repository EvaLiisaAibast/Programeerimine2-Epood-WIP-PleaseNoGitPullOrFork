using FluentValidation;

namespace KooliProjekt.Application.Features.Addresses
{
    public class GetAddressQueryValidator : AbstractValidator<GetAddressQuery>
    {
        public GetAddressQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
