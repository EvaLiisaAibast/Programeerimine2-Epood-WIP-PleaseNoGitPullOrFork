using FluentValidation;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class GetWarehouseTransferLineQueryValidator : AbstractValidator<GetWarehouseTransferLineQuery>
    {
        public GetWarehouseTransferLineQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
