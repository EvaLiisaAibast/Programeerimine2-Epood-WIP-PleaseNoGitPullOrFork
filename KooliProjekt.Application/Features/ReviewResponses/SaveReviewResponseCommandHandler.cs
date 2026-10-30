using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class SaveReviewResponseCommandHandler : IRequestHandler<SaveReviewResponseCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveReviewResponseCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveReviewResponseCommand request, CancellationToken cancellationToken)
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

            ReviewResponse entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ReviewResponses.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ReviewResponse();
                _dbContext.ReviewResponses.Add(entity);
            }

            entity.ReviewId = request.Data.ReviewId;
            entity.EmployeeId = request.Data.EmployeeId;
            entity.Content = request.Data.Content;
            entity.CreatedAt = request.Data.CreatedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
