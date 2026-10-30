using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.OptionValues
{
    public class SaveOptionValueCommandHandler : IRequestHandler<SaveOptionValueCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveOptionValueCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveOptionValueCommand request, CancellationToken cancellationToken)
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

            OptionValue entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.OptionValues.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new OptionValue();
                _dbContext.OptionValues.Add(entity);
            }

            entity.ProductOptionId = request.Data.ProductOptionId;
            entity.Value = request.Data.Value;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
