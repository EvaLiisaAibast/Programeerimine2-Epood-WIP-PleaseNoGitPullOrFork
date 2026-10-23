using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, OperationResult<CategoryDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetCategoryQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<CategoryDto>();

            response.Value = await _dbContext.Categories
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    ParentCategoryId = x.ParentCategoryId,
                    ParentCategoryName = _dbContext.Categories.Where(t => t.Id == x.ParentCategoryId).Select(t => t.Name).FirstOrDefault(),
                    Name = x.Name,
                    Description = x.Description,
                })
                .FirstOrDefaultAsync(cancellationToken);

            return response;
        }
    }
}
