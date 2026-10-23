using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockMovements
{
    public class GetStockMovementQuery : IRequest<OperationResult<StockMovementDto>>
    {
        public int Id { get; set; }
    }
}
