using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class DeleteAuditLogCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
