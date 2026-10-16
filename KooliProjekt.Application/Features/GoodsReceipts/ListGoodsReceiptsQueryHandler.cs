using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class ListGoodsReceiptsQueryHandler : IRequestHandler<ListGoodsReceiptsQuery, IEnumerable<GoodsReceipt>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListGoodsReceiptsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GoodsReceipt>> Handle(ListGoodsReceiptsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.GoodsReceipts.ToListAsync(cancellationToken);

            return result;
        }
    }
}
