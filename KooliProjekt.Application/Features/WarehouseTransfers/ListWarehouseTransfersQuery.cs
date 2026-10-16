using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class ListWarehouseTransfersQuery : IRequest<IEnumerable<WarehouseTransfer>>
    {
    }
}
