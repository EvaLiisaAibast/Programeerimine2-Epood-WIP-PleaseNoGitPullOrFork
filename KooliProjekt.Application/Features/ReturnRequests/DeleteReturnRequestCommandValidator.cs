using FluentValidation;

namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class DeleteReturnRequestCommandValidator : AbstractValidator<DeleteReturnRequestCommand>
    {
        public DeleteReturnRequestCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
