using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class GetPurchaseOrderLineQuery : IRequest<OperationResult<PurchaseOrderLineDto>>
    {
        public int Id { get; set; }
    }
}
