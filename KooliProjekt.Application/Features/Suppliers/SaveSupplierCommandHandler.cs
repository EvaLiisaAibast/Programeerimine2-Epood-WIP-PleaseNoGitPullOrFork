using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Suppliers
{
    public class SaveSupplierCommandHandler : IRequestHandler<SaveSupplierCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveSupplierCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveSupplierCommand request, CancellationToken cancellationToken)
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

            Supplier entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Suppliers.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Supplier();
                _dbContext.Suppliers.Add(entity);
            }

            entity.Name = request.Data.Name;
            entity.ContactEmail = request.Data.ContactEmail;
            entity.Phone = request.Data.Phone;
            entity.ContractReference = request.Data.ContractReference;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
