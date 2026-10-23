using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class GetGoodsReceiptQuery : IRequest<OperationResult<GoodsReceiptDto>>
    {
        public int Id { get; set; }
    }
}
