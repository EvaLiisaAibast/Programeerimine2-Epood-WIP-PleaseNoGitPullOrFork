using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class SaveAuditLogCommand : IRequest<OperationResult<int>>
    {
        public AuditLogDto Data { get; set; }
    }
}
