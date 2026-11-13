using FluentValidation;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class GetSupplierQueryValidator : AbstractValidator<GetSupplierQuery>
    {
        public GetSupplierQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
