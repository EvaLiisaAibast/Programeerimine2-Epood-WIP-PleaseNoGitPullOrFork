using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class DeleteStockMovementCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
