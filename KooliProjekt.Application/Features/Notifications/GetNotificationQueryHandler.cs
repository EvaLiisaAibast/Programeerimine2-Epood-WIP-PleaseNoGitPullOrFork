using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Notifications
{
    public class GetNotificationQueryHandler : IRequestHandler<GetNotificationQuery, Notification>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetNotificationQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Notification> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Notifications.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
