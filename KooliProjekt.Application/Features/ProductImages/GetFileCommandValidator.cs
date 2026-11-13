using FluentValidation;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetFileCommandValidator : AbstractValidator<GetFileCommand>
    {
        public GetFileCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
