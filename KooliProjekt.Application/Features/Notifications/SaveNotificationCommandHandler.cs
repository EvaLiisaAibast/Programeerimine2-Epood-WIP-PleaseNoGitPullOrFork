using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Notifications
{
    public class SaveNotificationCommandHandler : IRequestHandler<SaveNotificationCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveNotificationCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveNotificationCommand request, CancellationToken cancellationToken)
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

            Notification entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Notifications.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Notification();
                _dbContext.Notifications.Add(entity);
            }

            entity.CustomerId = request.Data.CustomerId;
            entity.Type = request.Data.Type;
            entity.Title = request.Data.Title;
            entity.Message = request.Data.Message;
            entity.CreatedAt = request.Data.CreatedAt;
            entity.ReadAt = request.Data.ReadAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
