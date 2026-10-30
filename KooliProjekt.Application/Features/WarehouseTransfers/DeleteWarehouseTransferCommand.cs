using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class DeleteWarehouseTransferCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
