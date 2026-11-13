using FluentValidation;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class GetReturnLineQueryValidator : AbstractValidator<GetReturnLineQuery>
    {
        public GetReturnLineQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
