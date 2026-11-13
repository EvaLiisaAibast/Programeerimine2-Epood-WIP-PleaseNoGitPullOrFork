using FluentValidation;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class ListAuditLogsQueryValidator : AbstractValidator<ListAuditLogsQuery>
    {
        public ListAuditLogsQueryValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1).WithMessage("Lehekülg peab olema suurem kui 0.");

            RuleFor(x => x.PageSize)
                .GreaterThanOrEqualTo(1).WithMessage("Lehekülje suurus peab olema suurem kui 0.")
                .LessThanOrEqualTo(100).WithMessage("Lehekülje suurus võib olla kuni 100.");
        }
    }
}
