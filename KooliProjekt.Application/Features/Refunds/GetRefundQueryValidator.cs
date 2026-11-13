using FluentValidation;

namespace KooliProjekt.Application.Features.Refunds
{
    public class GetRefundQueryValidator : AbstractValidator<GetRefundQuery>
    {
        public GetRefundQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
