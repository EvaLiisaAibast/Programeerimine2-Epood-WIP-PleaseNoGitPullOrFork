using FluentValidation;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class GetOptionValueQueryValidator : AbstractValidator<GetOptionValueQuery>
    {
        public GetOptionValueQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
