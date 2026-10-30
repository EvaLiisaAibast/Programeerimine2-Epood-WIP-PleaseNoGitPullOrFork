using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.VariantOptions
{
    public class SaveVariantOptionCommandHandler : IRequestHandler<SaveVariantOptionCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveVariantOptionCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveVariantOptionCommand request, CancellationToken cancellationToken)
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

            VariantOption entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.VariantOptions.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new VariantOption();
                _dbContext.VariantOptions.Add(entity);
            }

            entity.VariantId = request.Data.VariantId;
            entity.OptionValueId = request.Data.OptionValueId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
