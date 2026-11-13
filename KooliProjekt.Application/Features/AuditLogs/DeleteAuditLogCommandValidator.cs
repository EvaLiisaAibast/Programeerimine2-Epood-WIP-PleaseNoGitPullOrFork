using FluentValidation;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class DeleteAuditLogCommandValidator : AbstractValidator<DeleteAuditLogCommand>
    {
        public DeleteAuditLogCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
