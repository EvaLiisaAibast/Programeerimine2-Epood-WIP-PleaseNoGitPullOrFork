using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class GetPurchaseOrderQuery : IRequest<PurchaseOrder>
    {
        public int Id { get; set; }
    }
}
