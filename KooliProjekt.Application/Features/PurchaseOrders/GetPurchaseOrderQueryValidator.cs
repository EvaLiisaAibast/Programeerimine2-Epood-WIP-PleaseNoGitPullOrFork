using FluentValidation;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class GetPurchaseOrderQueryValidator : AbstractValidator<GetPurchaseOrderQuery>
    {
        public GetPurchaseOrderQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
