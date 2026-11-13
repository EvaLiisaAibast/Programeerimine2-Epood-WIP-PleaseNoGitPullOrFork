using FluentValidation;

namespace KooliProjekt.Application.Features.Coupons
{
    public class DeleteCouponCommandValidator : AbstractValidator<DeleteCouponCommand>
    {
        public DeleteCouponCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
