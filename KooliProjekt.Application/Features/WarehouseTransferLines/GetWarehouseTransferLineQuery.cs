using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class GetWarehouseTransferLineQuery : IRequest<OperationResult<WarehouseTransferLineDto>>
    {
        public int Id { get; set; }
    }
}
