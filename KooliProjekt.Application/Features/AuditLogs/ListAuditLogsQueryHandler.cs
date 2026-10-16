using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.AuditLogs
{
    public class ListAuditLogsQueryHandler : IRequestHandler<ListAuditLogsQuery, IEnumerable<AuditLog>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListAuditLogsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AuditLog>> Handle(ListAuditLogsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.AuditLogs.ToListAsync(cancellationToken);

            return result;
        }
    }
}
