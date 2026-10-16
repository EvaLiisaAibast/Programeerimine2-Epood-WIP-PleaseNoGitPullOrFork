using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.VariantOptions
{
    public class GetVariantOptionQueryHandler : IRequestHandler<GetVariantOptionQuery, VariantOption>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetVariantOptionQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VariantOption> Handle(GetVariantOptionQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.VariantOptions.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
