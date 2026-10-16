using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class GetGoodsReceiptQuery : IRequest<GoodsReceipt>
    {
        public int Id { get; set; }
    }
}
