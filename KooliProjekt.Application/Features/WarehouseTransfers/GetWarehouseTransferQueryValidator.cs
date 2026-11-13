using FluentValidation;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class GetWarehouseTransferQueryValidator : AbstractValidator<GetWarehouseTransferQuery>
    {
        public GetWarehouseTransferQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
