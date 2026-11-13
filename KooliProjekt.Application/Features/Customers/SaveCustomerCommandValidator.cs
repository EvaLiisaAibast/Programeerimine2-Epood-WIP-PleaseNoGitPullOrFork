using FluentValidation;

namespace KooliProjekt.Application.Features.Customers
{
    public class SaveCustomerCommandValidator : AbstractValidator<SaveCustomerCommand>
    {
        public SaveCustomerCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email on kohustuslik.")
                .MaximumLength(100).WithMessage("Email võib olla kuni 100 tähemärki.")
                .EmailAddress().WithMessage("Email peab olema korrektne e-posti aadress.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("FirstName on kohustuslik.")
                .MaximumLength(100).WithMessage("FirstName võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("LastName on kohustuslik.")
                .MaximumLength(100).WithMessage("LastName võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Phone)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(50).WithMessage("Phone võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
