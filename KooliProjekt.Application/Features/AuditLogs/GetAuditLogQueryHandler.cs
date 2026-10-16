using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.AuditLogs
{
    public class GetAuditLogQueryHandler : IRequestHandler<GetAuditLogQuery, AuditLog>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAuditLogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuditLog> Handle(GetAuditLogQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.AuditLogs.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
