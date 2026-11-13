using FluentValidation;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class DeleteReviewImageCommandValidator : AbstractValidator<DeleteReviewImageCommand>
    {
        public DeleteReviewImageCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
