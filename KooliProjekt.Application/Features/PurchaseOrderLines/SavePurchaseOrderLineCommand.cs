using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class SavePurchaseOrderLineCommand : IRequest<OperationResult<int>>
    {
        public PurchaseOrderLineDto Data { get; set; }
    }
}
