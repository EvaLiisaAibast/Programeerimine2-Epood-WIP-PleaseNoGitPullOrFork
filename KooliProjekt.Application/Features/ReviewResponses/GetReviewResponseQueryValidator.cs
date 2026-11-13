using FluentValidation;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class GetReviewResponseQueryValidator : AbstractValidator<GetReviewResponseQuery>
    {
        public GetReviewResponseQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
