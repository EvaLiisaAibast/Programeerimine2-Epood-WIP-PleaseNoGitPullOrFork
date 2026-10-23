using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Notifications
{
    public class ListNotificationsQueryHandler : IRequestHandler<ListNotificationsQuery, OperationResult<PagedResult<NotificationListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListNotificationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<NotificationListItemDto>>> Handle(ListNotificationsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<NotificationListItemDto>>();

            response.Value = await _dbContext.Notifications
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new NotificationListItemDto
                {
                    Id = x.Id,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Type = x.Type,
                    Title = x.Title,
                    CreatedAt = x.CreatedAt,
                    ReadAt = x.ReadAt,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
