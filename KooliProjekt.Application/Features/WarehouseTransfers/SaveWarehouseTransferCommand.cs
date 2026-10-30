using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class SaveWarehouseTransferCommand : IRequest<OperationResult<int>>
    {
        public WarehouseTransferDto Data { get; set; }
    }
}
