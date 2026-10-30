using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrders
{
    public class SavePurchaseOrderCommand : IRequest<OperationResult<int>>
    {
        public PurchaseOrderDto Data { get; set; }
    }
}
