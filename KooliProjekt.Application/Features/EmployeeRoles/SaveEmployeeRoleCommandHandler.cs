using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.EmployeeRoles
{
    public class SaveEmployeeRoleCommandHandler : IRequestHandler<SaveEmployeeRoleCommand, OperationResult<int>>
    {
        private readonly ApplicationDbContext _dbContext;

        public SaveEmployeeRoleCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<int>> Handle(SaveEmployeeRoleCommand request, CancellationToken cancellationToken)
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

            EmployeeRole entity;

            if (request.Data.Id > 0)
            {
                entity = await _dbContext.EmployeeRoles.FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

                if (entity == null)
                {
                    return response.AddError("Kirjet ei leitud.");
                }
            }
            else
            {
                entity = new EmployeeRole();
                _dbContext.EmployeeRoles.Add(entity);
            }

            entity.EmployeeId = request.Data.EmployeeId;
            entity.Role = request.Data.Role;

            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = entity.Id;

            return response;
        }
    }
}
