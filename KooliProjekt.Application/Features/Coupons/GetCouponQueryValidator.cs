using FluentValidation;

namespace KooliProjekt.Application.Features.Coupons
{
    public class GetCouponQueryValidator : AbstractValidator<GetCouponQuery>
    {
        public GetCouponQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
