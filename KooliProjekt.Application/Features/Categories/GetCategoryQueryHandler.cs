using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCategoryQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Categories.FindAsync(request.Id, cancellationToken);

            return result;
        }
    }
}
