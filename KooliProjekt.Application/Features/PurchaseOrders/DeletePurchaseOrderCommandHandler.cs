using System.Threading;
using System.Threading.Tasks;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class DeletePurchaseOrderCommandHandler : IRequestHandler<DeletePurchaseOrderCommand, OperationResult<bool>>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeletePurchaseOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperationResult<bool>> Handle(DeletePurchaseOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new OperationResult<bool>();

            if (request.Id <= 0)
            {
                return response.AddError("Id peab olema suurem kui 0.");
            }

            var entity = await _dbContext.PurchaseOrders.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                return response.AddError("Kirjet ei leitud.");
            }

            _dbContext.PurchaseOrders.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            response.Value = true;

            return response;
        }
    }
}
