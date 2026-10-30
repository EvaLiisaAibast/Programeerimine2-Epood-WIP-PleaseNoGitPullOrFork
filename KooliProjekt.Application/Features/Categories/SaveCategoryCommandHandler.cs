using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Categories
{
    public class SaveCategoryCommandHandler : IRequestHandler<SaveCategoryCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCategoryCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<int>();

            if (request.Data == null)
            {
                return response.AddError("Andmed puuduvad.");
            }

            if (request.Data.Id < 0)
            {
                return response.AddError("Id ei tohi olla negatiivne.");
            }

            Category entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Category();
                _dbContext.Categories.Add(entity);
            }

            entity.ParentCategoryId = request.Data.ParentCategoryId;
            entity.Name = request.Data.Name;
            entity.Description = request.Data.Description;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
