using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class GetSupportTicketQueryHandler : IRequestHandler<GetSupportTicketQuery, OperationResult<SupportTicketDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetSupportTicketQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<SupportTicketDto>> Handle(GetSupportTicketQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<SupportTicketDto>();

            response.Value = await _dbContext.SupportTickets
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new SupportTicketDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    CustomerName = _dbContext.Customers.Where(t => t.Id == x.CustomerId).Select(t => t.FirstName + " " + t.LastName).FirstOrDefault(),
                    ResponsibleEmployeeId = x.ResponsibleEmployeeId,
                    ResponsibleEmployeeName = _dbContext.Employees.Where(t => t.Id == x.ResponsibleEmployeeId).Select(t => t.Name).FirstOrDefault(),
                    Subject = x.Subject,
                    Priority = x.Priority,
                    Status = x.Status,
                    CreatedAt = x.CreatedAt,
                    ClosedAt = x.ClosedAt,
                    Messages = _dbContext.TicketMessages
                        .Where(c => c.TicketId == x.Id)
                        .OrderBy(c => c.Id)
                        .Select(c => new TicketMessageDto
                        {
                            Id = c.Id,
                            TicketId = c.TicketId,
                            TicketSubject = _dbContext.SupportTickets.Where(t => t.Id == c.TicketId).Select(t => t.Subject).FirstOrDefault(),
                            SenderType = c.SenderType,
                            SenderId = c.SenderId,
                            Content = c.Content,
                            CreatedAt = c.CreatedAt,
                        })
                        .ToList(),
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
