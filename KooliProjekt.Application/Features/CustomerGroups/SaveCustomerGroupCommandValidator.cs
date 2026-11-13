using FluentValidation;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class SaveCustomerGroupCommandValidator : AbstractValidator<SaveCustomerGroupCommand>
    {
        public SaveCustomerGroupCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.GroupName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("GroupName on kohustuslik.")
                .MaximumLength(100).WithMessage("GroupName võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.DiscountPercent)
                .Cascade(CascadeMode.Stop)
                .InclusiveBetween(0, 100).WithMessage("DiscountPercent peab olema vahemikus 0 kuni 100.")
                .When(x => x.Data != null);
        }
    }
}
