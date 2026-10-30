using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.PurchaseOrderLines
{
    public class DeletePurchaseOrderLineCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
