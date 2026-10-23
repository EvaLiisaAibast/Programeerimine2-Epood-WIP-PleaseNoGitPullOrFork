using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Paging;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.GiftCards
{
    public class ListGiftCardsQueryHandler : IRequestHandler<ListGiftCardsQuery, OperationResult<PagedResult<GiftCardListItemDto>>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListGiftCardsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<PagedResult<GiftCardListItemDto>>> Handle(ListGiftCardsQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<PagedResult<GiftCardListItemDto>>();

            response.Value = await _dbContext.GiftCards
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Select(x => new GiftCardListItemDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    InitialAmount = x.InitialAmount,
                    Balance = x.Balance,
                    ExpiryDate = x.ExpiryDate,
                })
                .GetPagedAsync(request.Page, request.PageSize);

            return response;
        }
    }
}
