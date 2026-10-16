using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class GetGoodsReceiptQueryHandler : IRequestHandler<GetGoodsReceiptQuery, GoodsReceipt>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetGoodsReceiptQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GoodsReceipt> Handle(GetGoodsReceiptQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.GoodsReceipts.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
