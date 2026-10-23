using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class GetWarehouseTransferQuery : IRequest<OperationResult<WarehouseTransferDto>>
    {
        public int Id { get; set; }
    }
}
