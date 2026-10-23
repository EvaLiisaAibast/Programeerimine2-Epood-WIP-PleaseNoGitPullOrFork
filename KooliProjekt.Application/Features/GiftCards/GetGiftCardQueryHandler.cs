using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class GetGiftCardQueryHandler : IRequestHandler<GetGiftCardQuery, OperationResult<GiftCardDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGiftCardQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<GiftCardDto>> Handle(GetGiftCardQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<GiftCardDto>();

            response.Value = await _dbContext.GiftCards
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new GiftCardDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    InitialAmount = x.InitialAmount,
                    Balance = x.Balance,
                    ExpiryDate = x.ExpiryDate,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
