using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.SupportTickets
{
    public class SaveSupportTicketCommandHandler : IRequestHandler<SaveSupportTicketCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveSupportTicketCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveSupportTicketCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            if (request.Data == null)
            {
                return response.AddError("Andmed puuduvad.");
            }

            if (request.Data.Id < 0)
            {
                return response.AddError("Id ei tohi olla negatiivne.");
            }

            SupportTicket entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.SupportTickets.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new SupportTicket();
                _dbContext.SupportTickets.Add(entity);
            }

            entity.CustomerId = request.Data.CustomerId;
            entity.ResponsibleEmployeeId = request.Data.ResponsibleEmployeeId;
            entity.Subject = request.Data.Subject;
            entity.Priority = request.Data.Priority;
            entity.Status = request.Data.Status;
            entity.CreatedAt = request.Data.CreatedAt;
            entity.ClosedAt = request.Data.ClosedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
