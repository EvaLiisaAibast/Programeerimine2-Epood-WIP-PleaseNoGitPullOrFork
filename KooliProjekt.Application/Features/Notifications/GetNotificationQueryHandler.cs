using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Notifications
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, OperationResult<NotificationDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetNotificationQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<NotificationDto>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<NotificationDto>();

            response.Value = await _dbContext.Notifications
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new NotificationDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    Type = x.Type,
                    Title = x.Title,
                    Message = x.Message,
                    CreatedAt = x.CreatedAt,
                    ReadAt = x.ReadAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
