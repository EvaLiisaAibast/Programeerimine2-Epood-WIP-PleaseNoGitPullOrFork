using FluentValidation;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class DeletePurchaseOrderCommandValidator : AbstractValidator<DeletePurchaseOrderCommand>
    {
        public DeletePurchaseOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
