using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.GiftCards
{
    public class ListGiftCardsQueryHandler : IRequestHandler<ListGiftCardsQuery, IEnumerable<GiftCard>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListGiftCardsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GiftCard>> Handle(ListGiftCardsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.GiftCards.ToListAsync(cancellationToken);

            return result;
        }
    }
}
