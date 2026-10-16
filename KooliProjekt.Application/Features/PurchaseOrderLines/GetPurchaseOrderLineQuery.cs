using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class GetPurchaseOrderLineQuery : IRequest<PurchaseOrderLine>
    {
        public int Id { get; set; }
    }
}
