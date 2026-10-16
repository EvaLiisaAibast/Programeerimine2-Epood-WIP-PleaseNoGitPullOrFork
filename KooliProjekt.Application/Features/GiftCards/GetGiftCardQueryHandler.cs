using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.GiftCards
{
    public class GetGiftCardQueryHandler : IRequestHandler<GetGiftCardQuery, GiftCard>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGiftCardQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GiftCard> Handle(GetGiftCardQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.GiftCards.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
