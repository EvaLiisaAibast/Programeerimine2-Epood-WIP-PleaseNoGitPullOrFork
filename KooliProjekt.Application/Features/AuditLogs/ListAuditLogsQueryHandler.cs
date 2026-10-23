using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.AuditLogs
{
    public class ListAuditLogsQueryHandler : IRequestHandler<ListAuditLogsQuery, OperationResult<PagedResult<AuditLogListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListAuditLogsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<AuditLogListItemDto>>> Handle(ListAuditLogsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<AuditLogListItemDto>>();

            response.Value = await _dbContext.AuditLogs
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new AuditLogListItemDto
                {
                    Id = x.Id,
                    EmployeeName = _dbContext.Employees.Where(t => t.Id == x.EmployeeId).Select(t => t.Name).FirstOrDefault(),
                    ObjectType = x.ObjectType,
                    ObjectId = x.ObjectId,
                    Action = x.Action,
                    CreatedAt = x.CreatedAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
