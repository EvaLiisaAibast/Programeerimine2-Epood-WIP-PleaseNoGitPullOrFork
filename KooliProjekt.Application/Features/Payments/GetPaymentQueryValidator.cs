using FluentValidation;

namespace KooliProjekt.Application.Features.Payments
{
    public class GetPaymentQueryValidator : AbstractValidator<GetPaymentQuery>
    {
        public GetPaymentQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
