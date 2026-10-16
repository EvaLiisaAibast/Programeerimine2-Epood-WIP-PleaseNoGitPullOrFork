using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.TicketMessages
{
    public class ListTicketMessagesQueryHandler : IRequestHandler<ListTicketMessagesQuery, IEnumerable<TicketMessage>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListTicketMessagesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TicketMessage>> Handle(ListTicketMessagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.TicketMessages.ToListAsync(cancellationToken);

            return result;
        }
    }
}
