using FluentValidation;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class DeleteProductVideoCommandValidator : AbstractValidator<DeleteProductVideoCommand>
    {
        public DeleteProductVideoCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
