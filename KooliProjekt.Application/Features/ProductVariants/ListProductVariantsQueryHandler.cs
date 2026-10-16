using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ProductVariants
{
    public class ListProductVariantsQueryHandler : IRequestHandler<ListProductVariantsQuery, IEnumerable<ProductVariant>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductVariantsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductVariant>> Handle(ListProductVariantsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductVariants.ToListAsync(cancellationToken);

            return result;
        }
    }
}
