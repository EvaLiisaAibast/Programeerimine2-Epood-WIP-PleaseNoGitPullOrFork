using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class SaveWarehouseCommand : IRequest<OperationResult<int>>
    {
        public WarehouseDto Data { get; set; }
    }
}
