using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class SaveWarehouseTransferLineCommand : IRequest<OperationResult<int>>
    {
        public WarehouseTransferLineDto Data { get; set; }
    }
}
