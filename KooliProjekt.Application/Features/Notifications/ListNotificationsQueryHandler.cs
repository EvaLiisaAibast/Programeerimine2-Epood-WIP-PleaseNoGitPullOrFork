using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Notifications
{
    public class ListNotificationsQueryHandler : IRequestHandler<ListNotificationsQuery, IEnumerable<Notification>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListNotificationsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Notification>> Handle(ListNotificationsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Notifications.ToListAsync(cancellationToken);

            return result;
        }
    }
}
