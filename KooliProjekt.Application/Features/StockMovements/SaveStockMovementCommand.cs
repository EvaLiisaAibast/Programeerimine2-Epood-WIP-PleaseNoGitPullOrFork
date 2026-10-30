using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class SaveStockMovementCommand : IRequest<OperationResult<int>>
    {
        public StockMovementDto Data { get; set; }
    }
}
