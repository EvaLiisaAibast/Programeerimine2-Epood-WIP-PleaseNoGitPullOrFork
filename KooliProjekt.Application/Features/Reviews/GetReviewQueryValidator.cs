using FluentValidation;

namespace KooliProjekt.Application.Features.Reviews
{
    public class GetReviewQueryValidator : AbstractValidator<GetReviewQuery>
    {
        public GetReviewQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
