using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WarehouseTransfers
{
    public class GetWarehouseTransferQuery : IRequest<WarehouseTransfer>
    {
        public int Id { get; set; }
    }
}
