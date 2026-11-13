using FluentValidation;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class GetReturnRequestQueryValidator : AbstractValidator<GetReturnRequestQuery>
    {
        public GetReturnRequestQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
