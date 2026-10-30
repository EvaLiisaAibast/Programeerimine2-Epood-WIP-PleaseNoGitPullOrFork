using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.CustomerGroups
{
    public class DeleteCustomerGroupCommandHandler : IRequestHandler<DeleteCustomerGroupCommand, OperationResult<bool>>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteCustomerGroupCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<bool>> Handle(DeleteCustomerGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<bool>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.CustomerGroups.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Kirjet ei leitud.");
            }

            _dbContext.CustomerGroups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = true;

            return response;
        }
    }
}
