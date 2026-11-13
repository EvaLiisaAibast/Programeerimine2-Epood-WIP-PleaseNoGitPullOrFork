using FluentValidation;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class DeletePurchaseOrderLineCommandValidator : AbstractValidator<DeletePurchaseOrderLineCommand>
    {
        public DeletePurchaseOrderLineCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
