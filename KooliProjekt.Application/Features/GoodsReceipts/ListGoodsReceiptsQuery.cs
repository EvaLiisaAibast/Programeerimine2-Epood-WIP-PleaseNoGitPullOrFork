using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.GoodsReceipts
{
    public class ListGoodsReceiptsQuery : IRequest<IEnumerable<GoodsReceipt>>
    {
    }
}
