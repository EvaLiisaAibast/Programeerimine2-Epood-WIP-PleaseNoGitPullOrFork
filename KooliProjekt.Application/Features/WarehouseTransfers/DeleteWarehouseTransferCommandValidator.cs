using FluentValidation;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class DeleteWarehouseTransferCommandValidator : AbstractValidator<DeleteWarehouseTransferCommand>
    {
        public DeleteWarehouseTransferCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
