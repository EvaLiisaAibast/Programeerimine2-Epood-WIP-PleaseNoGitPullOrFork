using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Warehouses
{
    public class ListWarehousesQuery : IRequest<IEnumerable<Warehouse>>
    {
    }
}
