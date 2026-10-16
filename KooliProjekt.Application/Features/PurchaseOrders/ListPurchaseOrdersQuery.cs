using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class ListPurchaseOrdersQuery : IRequest<IEnumerable<PurchaseOrder>>
    {
    }
}
