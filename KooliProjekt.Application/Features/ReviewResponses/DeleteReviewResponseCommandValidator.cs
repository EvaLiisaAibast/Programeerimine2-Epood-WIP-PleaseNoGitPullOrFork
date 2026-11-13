using FluentValidation;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class DeleteReviewResponseCommandValidator : AbstractValidator<DeleteReviewResponseCommand>
    {
        public DeleteReviewResponseCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
