using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class DeleteWarehouseCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
