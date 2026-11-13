using FluentValidation;

namespace KooliProjekt.Application.Features.Notifications
{
    public class SaveNotificationCommandValidator : AbstractValidator<SaveNotificationCommand>
    {
        public SaveNotificationCommandValidator()
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

            RuleFor(x => x.Data.Type)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Type on kohustuslik.")
                .MaximumLength(50).WithMessage("Type võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title on kohustuslik.")
                .MaximumLength(200).WithMessage("Title võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Message)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Message on kohustuslik.")
                .MaximumLength(2000).WithMessage("Message võib olla kuni 2000 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
