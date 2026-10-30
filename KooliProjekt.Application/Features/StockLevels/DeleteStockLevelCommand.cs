using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.StockLevels
{
    public class DeleteStockLevelCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
