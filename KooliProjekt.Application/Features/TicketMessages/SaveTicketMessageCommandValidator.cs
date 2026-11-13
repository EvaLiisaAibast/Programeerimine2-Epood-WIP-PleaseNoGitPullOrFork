using FluentValidation;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class SaveTicketMessageCommandValidator : AbstractValidator<SaveTicketMessageCommand>
    {
        public SaveTicketMessageCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.TicketId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("TicketId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.SenderType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("SenderType on kohustuslik.")
                .MaximumLength(50).WithMessage("SenderType võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.SenderId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("SenderId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Content on kohustuslik.")
                .MaximumLength(4000).WithMessage("Content võib olla kuni 4000 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
