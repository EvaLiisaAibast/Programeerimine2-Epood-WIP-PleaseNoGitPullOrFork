using FluentValidation;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class DeleteWarehouseCommandValidator : AbstractValidator<DeleteWarehouseCommand>
    {
        public DeleteWarehouseCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
