using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Brands
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, Brand>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetBrandQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Brand> Handle(GetBrandQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Brands.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
