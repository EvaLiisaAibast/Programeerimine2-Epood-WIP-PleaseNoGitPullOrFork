using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.AuditLogs
{
    public class ListAuditLogsQuery : IRequest<IEnumerable<AuditLog>>
    {
    }
}
