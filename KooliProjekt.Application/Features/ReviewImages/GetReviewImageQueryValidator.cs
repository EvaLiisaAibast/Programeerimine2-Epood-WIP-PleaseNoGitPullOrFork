using FluentValidation;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class GetReviewImageQueryValidator : AbstractValidator<GetReviewImageQuery>
    {
        public GetReviewImageQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
