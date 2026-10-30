using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class DeleteWarehouseTransferLineCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
