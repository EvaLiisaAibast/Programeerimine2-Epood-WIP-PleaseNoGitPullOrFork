using FluentValidation;

namespace KooliProjekt.Application.Features.Payments
{
    public class DeletePaymentCommandValidator : AbstractValidator<DeletePaymentCommand>
    {
        public DeletePaymentCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
