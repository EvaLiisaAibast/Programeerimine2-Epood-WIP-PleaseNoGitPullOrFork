using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.TicketMessages
{
    public class GetTicketMessageQueryHandler : IRequestHandler<GetTicketMessageQuery, OperationResult<TicketMessageDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetTicketMessageQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<TicketMessageDto>> Handle(GetTicketMessageQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<TicketMessageDto>();

            response.Value = await _dbContext.TicketMessages
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new TicketMessageDto
                {
                    Id = x.Id,
                    TicketId = x.TicketId,
                    TicketSubject = _dbContext.SupportTickets.Where(t => t.Id == x.TicketId).Select(t => t.Subject).FirstOrDefault(),
                    SenderType = x.SenderType,
                    SenderId = x.SenderId,
                    Content = x.Content,
                    CreatedAt = x.CreatedAt,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
