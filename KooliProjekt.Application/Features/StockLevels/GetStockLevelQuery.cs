using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class GetStockLevelQuery : IRequest<OperationResult<StockLevelDto>>
    {
        public int Id { get; set; }
    }
}
