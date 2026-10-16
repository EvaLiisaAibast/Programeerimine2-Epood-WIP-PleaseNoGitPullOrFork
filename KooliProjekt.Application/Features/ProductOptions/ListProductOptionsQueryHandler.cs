using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ProductOptions
{
    public class ListProductOptionsQueryHandler : IRequestHandler<ListProductOptionsQuery, IEnumerable<ProductOption>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductOptionsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductOption>> Handle(ListProductOptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductOptions.ToListAsync(cancellationToken);

            return result;
        }
    }
}
