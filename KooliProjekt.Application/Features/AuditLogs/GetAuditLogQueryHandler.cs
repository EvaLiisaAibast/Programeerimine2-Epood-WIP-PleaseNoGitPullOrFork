using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class GetAuditLogQueryHandler : IRequestHandler<GetAuditLogQuery, OperationResult<AuditLogDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAuditLogQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<AuditLogDto>> Handle(GetAuditLogQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<AuditLogDto>();

            response.Value = await _dbContext.AuditLogs
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new AuditLogDto
                {
                    Id = x.Id,
                    EmployeeId = x.EmployeeId,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                    ObjectType = x.ObjectType,
                    ObjectId = x.ObjectId,
                    Action = x.Action,
                    OldValue = x.OldValue,
                    NewValue = x.NewValue,
                    IpAddress = x.IpAddress,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
