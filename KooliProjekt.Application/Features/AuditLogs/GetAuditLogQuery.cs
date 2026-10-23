using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class GetAuditLogQuery : IRequest<OperationResult<AuditLogDto>>
    {
        public int Id { get; set; }
    }
}
