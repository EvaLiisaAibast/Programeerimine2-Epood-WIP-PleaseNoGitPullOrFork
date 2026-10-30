using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.Employees
{
    public class SaveEmployeeCommandHandler : IRequestHandler<SaveEmployeeCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveEmployeeCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveEmployeeCommand request, CancellationToken cancellationToken)
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

            Employee entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new Employee();
                _dbContext.Employees.Add(entity);
                entity.PasswordHash = string.Empty;
            }

            entity.Name = request.Data.Name;
            entity.Email = request.Data.Email;
            entity.DepartmentId = request.Data.DepartmentId;
            entity.CreatedAt = request.Data.CreatedAt;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
