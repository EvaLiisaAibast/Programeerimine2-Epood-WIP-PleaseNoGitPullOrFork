using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.Categories
{
    public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListCategoriesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Categories.ToListAsync(cancellationToken);

            return result;
        }
    }
}
