using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class SaveStockLevelCommand : IRequest<OperationResult<int>>
    {
        public StockLevelDto Data { get; set; }
    }
}
