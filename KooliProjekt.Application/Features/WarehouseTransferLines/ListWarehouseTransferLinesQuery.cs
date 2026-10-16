using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class ListWarehouseTransferLinesQuery : IRequest<IEnumerable<WarehouseTransferLine>>
    {
    }
}
