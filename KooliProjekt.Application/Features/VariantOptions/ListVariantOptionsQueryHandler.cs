using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.VariantOptions
{
    public class ListVariantOptionsQueryHandler : IRequestHandler<ListVariantOptionsQuery, IEnumerable<VariantOption>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListVariantOptionsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<VariantOption>> Handle(ListVariantOptionsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.VariantOptions.ToListAsync(cancellationToken);

            return result;
        }
    }
}
