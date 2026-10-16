using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.SupportTickets
{
    public class GetSupportTicketQueryHandler : IRequestHandler<GetSupportTicketQuery, SupportTicket>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetSupportTicketQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SupportTicket> Handle(GetSupportTicketQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.SupportTickets.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
