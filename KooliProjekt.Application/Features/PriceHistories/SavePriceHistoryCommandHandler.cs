using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PriceHistories
{
    public class SavePriceHistoryCommandHandler : IRequestHandler<SavePriceHistoryCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SavePriceHistoryCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SavePriceHistoryCommand request, CancellationToken cancellationToken)
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

            PriceHistory entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.PriceHistories.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new PriceHistory();
                _dbContext.PriceHistories.Add(entity);
            }

            entity.VariantId = request.Data.VariantId;
            entity.CurrentPrice = request.Data.CurrentPrice;
            entity.ValidFrom = request.Data.ValidFrom;
            entity.ValidTo = request.Data.ValidTo;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
