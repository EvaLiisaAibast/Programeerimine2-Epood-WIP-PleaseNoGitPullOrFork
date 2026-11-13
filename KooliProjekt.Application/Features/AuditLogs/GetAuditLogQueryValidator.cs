using FluentValidation;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class GetAuditLogQueryValidator : AbstractValidator<GetAuditLogQuery>
    {
        public GetAuditLogQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id peab olema suurem kui 0.");
        }
    }
}
