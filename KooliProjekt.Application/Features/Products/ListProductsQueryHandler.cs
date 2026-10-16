using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Products
{
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, IEnumerable<Product>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Products.ToListAsync(cancellationToken);

            return result;
        }
    }
}
