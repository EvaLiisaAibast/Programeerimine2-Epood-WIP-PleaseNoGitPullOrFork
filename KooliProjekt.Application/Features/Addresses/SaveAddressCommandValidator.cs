using FluentValidation;

namespace KooliProjekt.Application.Features.Addresses
{
    public class SaveAddressCommandValidator : AbstractValidator<SaveAddressCommand>
    {
        public SaveAddressCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.CustomerId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("CustomerId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Country)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Country on kohustuslik.")
                .MaximumLength(100).WithMessage("Country võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.City)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("City on kohustuslik.")
                .MaximumLength(100).WithMessage("City võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.PostalCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("PostalCode on kohustuslik.")
                .MaximumLength(20).WithMessage("PostalCode võib olla kuni 20 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Street)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Street on kohustuslik.")
                .MaximumLength(150).WithMessage("Street võib olla kuni 150 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.HouseNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("HouseNumber on kohustuslik.")
                .MaximumLength(20).WithMessage("HouseNumber võib olla kuni 20 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Apartment)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(20).WithMessage("Apartment võib olla kuni 20 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
