using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Customers
{
    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveCustomerCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
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

            Customer entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Customer();
                _dbContext.Customers.Add(entity);
                entity.PasswordHash = string.Empty;
            }

            entity.Email = request.Data.Email;
            entity.FirstName = request.Data.FirstName;
            entity.LastName = request.Data.LastName;
            entity.Phone = request.Data.Phone;
            entity.Status = request.Data.Status;
            entity.CreatedAt = request.Data.CreatedAt;
            entity.LastLogin = request.Data.LastLogin;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
