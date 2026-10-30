using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class SaveProductOptionCommandHandler : IRequestHandler<SaveProductOptionCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveProductOptionCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveProductOptionCommand request, CancellationToken cancellationToken)
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

            ProductOption entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.ProductOptions.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new ProductOption();
                _dbContext.ProductOptions.Add(entity);
            }

            entity.ProductId = request.Data.ProductId;
            entity.Name = request.Data.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
