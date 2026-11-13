using FluentValidation;

namespace KooliProjekt.Application.Features.Refunds
{
    public class DeleteRefundCommandValidator : AbstractValidator<DeleteRefundCommand>
    {
        public DeleteRefundCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
