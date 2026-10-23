using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class GetPurchaseOrderQuery : IRequest<OperationResult<PurchaseOrderDto>>
    {
        public int Id { get; set; }
    }
}
