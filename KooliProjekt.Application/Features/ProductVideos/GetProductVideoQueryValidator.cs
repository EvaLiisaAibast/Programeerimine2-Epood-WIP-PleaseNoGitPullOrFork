using FluentValidation;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class GetProductVideoQueryValidator : AbstractValidator<GetProductVideoQuery>
    {
        public GetProductVideoQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
