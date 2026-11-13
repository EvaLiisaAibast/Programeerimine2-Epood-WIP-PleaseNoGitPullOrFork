using FluentValidation;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class DeleteProductOptionCommandValidator : AbstractValidator<DeleteProductOptionCommand>
    {
        public DeleteProductOptionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
