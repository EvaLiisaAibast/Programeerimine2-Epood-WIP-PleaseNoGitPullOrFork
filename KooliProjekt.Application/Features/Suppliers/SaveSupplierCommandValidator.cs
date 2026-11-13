using FluentValidation;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class SaveSupplierCommandValidator : AbstractValidator<SaveSupplierCommand>
    {
        public SaveSupplierCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name on kohustuslik.")
                .MaximumLength(200).WithMessage("Name võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ContactEmail)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(100).WithMessage("ContactEmail võib olla kuni 100 tähemärki.")
                .EmailAddress().WithMessage("ContactEmail peab olema korrektne e-posti aadress.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Phone)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(50).WithMessage("Phone võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ContractReference)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(255).WithMessage("ContractReference võib olla kuni 255 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
