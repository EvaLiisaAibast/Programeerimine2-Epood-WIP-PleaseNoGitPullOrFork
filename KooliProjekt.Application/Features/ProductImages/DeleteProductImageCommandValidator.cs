using FluentValidation;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class DeleteProductImageCommandValidator : AbstractValidator<DeleteProductImageCommand>
    {
        public DeleteProductImageCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
