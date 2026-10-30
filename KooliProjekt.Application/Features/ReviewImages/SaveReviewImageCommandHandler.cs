using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class SaveReviewImageCommandHandler : IRequestHandler<SaveReviewImageCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveReviewImageCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveReviewImageCommand request, CancellationToken cancellationToken)
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

            ReviewImage entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ReviewImages.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ReviewImage();
                _dbContext.ReviewImages.Add(entity);
            }

            entity.ReviewId = request.Data.ReviewId;
            entity.Url = request.Data.Url;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
