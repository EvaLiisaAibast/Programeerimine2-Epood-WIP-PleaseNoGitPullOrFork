using FluentValidation;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class GetWarehouseQueryValidator : AbstractValidator<GetWarehouseQuery>
    {
        public GetWarehouseQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
