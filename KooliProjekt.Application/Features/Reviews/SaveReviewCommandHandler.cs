using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Reviews
{
    public class SaveReviewCommandHandler : IRequestHandler<SaveReviewCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveReviewCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveReviewCommand request, CancellationToken cancellationToken)
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

            Review entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Reviews.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Review();
                _dbContext.Reviews.Add(entity);
            }

            entity.CustomerId = request.Data.CustomerId;
            entity.ProductId = request.Data.ProductId;
            entity.OrderLineId = request.Data.OrderLineId;
            entity.Rating = request.Data.Rating;
            entity.Title = request.Data.Title;
            entity.Content = request.Data.Content;
            entity.CreatedAt = request.Data.CreatedAt;
            entity.Status = request.Data.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
