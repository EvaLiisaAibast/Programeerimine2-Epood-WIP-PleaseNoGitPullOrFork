using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class DeleteWarehouseTransferLineCommandHandler : IRequestHandler<DeleteWarehouseTransferLineCommand, OperationResult<bool>>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteWarehouseTransferLineCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<bool>> Handle(DeleteWarehouseTransferLineCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<bool>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.WarehouseTransferLines.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Kirjet ei leitud.");
            }

            _dbContext.WarehouseTransferLines.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = true;

            return response;
        }
    }
}
