using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.TicketMessages
{
    public class GetTicketMessageQueryHandler : IRequestHandler<GetTicketMessageQuery, TicketMessage>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTicketMessageQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TicketMessage> Handle(GetTicketMessageQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.TicketMessages.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
