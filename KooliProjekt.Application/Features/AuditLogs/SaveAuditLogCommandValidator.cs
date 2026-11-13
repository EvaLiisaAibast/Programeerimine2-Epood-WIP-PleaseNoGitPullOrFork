using FluentValidation;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class SaveAuditLogCommandValidator : AbstractValidator<SaveAuditLogCommand>
    {
        public SaveAuditLogCommandValidator()
        {
            RuleFor(x => x.Data)
                .NotNull().WithMessage("Andmed puuduvad.");

            RuleFor(x => x.Data.Id)
                .GreaterThanOrEqualTo(0).WithMessage("Id ei tohi olla negatiivne.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.EmployeeId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("EmployeeId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ObjectType)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("ObjectType on kohustuslik.")
                .MaximumLength(100).WithMessage("ObjectType võib olla kuni 100 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.ObjectId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(1).WithMessage("ObjectId ei tohi olla väiksem kui 1.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.Action)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Action on kohustuslik.")
                .MaximumLength(50).WithMessage("Action võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.OldValue)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(4000).WithMessage("OldValue võib olla kuni 4000 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.NewValue)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(4000).WithMessage("NewValue võib olla kuni 4000 tähemärki.")
                .When(x => x.Data != null);

            RuleFor(x => x.Data.IpAddress)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(50).WithMessage("IpAddress võib olla kuni 50 tähemärki.")
                .When(x => x.Data != null);
        }
    }
}
