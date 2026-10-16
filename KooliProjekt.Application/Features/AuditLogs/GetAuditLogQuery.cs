using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.AuditLogs
{
    public class GetAuditLogQuery : IRequest<AuditLog>
    {
        public int Id { get; set; }
    }
}
