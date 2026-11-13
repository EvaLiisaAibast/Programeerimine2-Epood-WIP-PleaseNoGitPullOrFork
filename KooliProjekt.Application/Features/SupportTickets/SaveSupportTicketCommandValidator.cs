using FluentValidation;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class SaveSupportTicketCommandValidator : AbstractValidator<SaveSupportTicketCommand>
    {
        public SaveSupportTicketCommandValidator()
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

            RuleFor(x => x.Data.ResponsibleEmployeeId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ResponsibleEmployeeId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Subject)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Subject on kohustuslik.")
                .MaximumLength(200).WithMessage("Subject võib olla kuni 200 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Priority)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Priority on kohustuslik.")
                .MaximumLength(50).WithMessage("Priority võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Status)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Status on kohustuslik.")
                .MaximumLength(50).WithMessage("Status võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
