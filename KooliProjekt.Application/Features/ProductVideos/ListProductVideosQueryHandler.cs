using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Application.Features.ProductVideos
{
    public class ListProductVideosQueryHandler : IRequestHandler<ListProductVideosQuery, IEnumerable<ProductVideo>>
    {
        private readonly ApplicationDbContext _dbContext;

        public ListProductVideosQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductVideo>> Handle(ListProductVideosQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.ProductVideos.ToListAsync(cancellationToken);

            return result;
        }
    }
}
