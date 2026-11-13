using FluentValidation;

namespace KooliProjekt.Application.Features.ReturnLines
{
    public class DeleteReturnLineCommandValidator : AbstractValidator<DeleteReturnLineCommand>
    {
        public DeleteReturnLineCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
