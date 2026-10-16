using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ProductImages
{
    public class ListProductImagesQueryHandler : IRequestHandler<ListProductImagesQuery, IEnumerable<ProductImage>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductImagesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductImage>> Handle(ListProductImagesQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductImages.ToListAsync(cancellationToken);

            return result;
        }
    }
}
