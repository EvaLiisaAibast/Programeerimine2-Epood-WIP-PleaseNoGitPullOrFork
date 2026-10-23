using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Warehouses
{
    public class GetWarehouseQuery : IRequest<OperationResult<WarehouseDto>>
    {
        public int Id { get; set; }
    }
}
