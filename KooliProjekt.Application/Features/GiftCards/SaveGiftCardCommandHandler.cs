using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class SaveGiftCardCommandHandler : IRequestHandler<SaveGiftCardCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveGiftCardCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveGiftCardCommand request, CancellationToken cancellationToken)
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

            GiftCard entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.GiftCards.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new GiftCard();
                _dbContext.GiftCards.Add(entity);
            }

            entity.Code = request.Data.Code;
            entity.InitialAmount = request.Data.InitialAmount;
            entity.Balance = request.Data.Balance;
            entity.ExpiryDate = request.Data.ExpiryDate;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
