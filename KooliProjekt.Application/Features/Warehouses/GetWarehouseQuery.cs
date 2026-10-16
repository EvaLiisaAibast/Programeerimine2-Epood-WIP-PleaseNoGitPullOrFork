using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Warehouses
{
    public class GetWarehouseQuery : IRequest<Warehouse>
    {
        public int Id { get; set; }
    }
}
