using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Brands
{
    public class ListBrandsQueryHandler : IRequestHandler<ListBrandsQuery, IEnumerable<Brand>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListBrandsQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Brand>> Handle(ListBrandsQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Brands.ToListAsync(cancellationToken);

            return result;
        }
    }
}
