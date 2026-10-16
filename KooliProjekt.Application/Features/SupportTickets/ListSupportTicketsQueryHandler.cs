using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.SupportTickets
{
    public class ListSupportTicketsQueryHandler : IRequestHandler<ListSupportTicketsQuery, IEnumerable<SupportTicket>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListSupportTicketsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SupportTicket>> Handle(ListSupportTicketsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.SupportTickets.ToListAsync(cancellationToken);

            return result;
        }
    }
}
