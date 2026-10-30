using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class SaveGoodsReceiptCommand : IRequest<OperationResult<int>>
    {
        public GoodsReceiptDto Data { get; set; }
    }
}
