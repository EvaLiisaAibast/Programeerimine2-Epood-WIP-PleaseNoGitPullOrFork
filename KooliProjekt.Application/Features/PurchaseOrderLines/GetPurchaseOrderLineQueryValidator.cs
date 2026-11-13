using FluentValidation;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class GetPurchaseOrderLineQueryValidator : AbstractValidator<GetPurchaseOrderLineQuery>
    {
        public GetPurchaseOrderLineQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
