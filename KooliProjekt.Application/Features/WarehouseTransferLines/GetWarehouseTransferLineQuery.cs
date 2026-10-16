using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.WarehouseTransferLines
{
    public class GetWarehouseTransferLineQuery : IRequest<WarehouseTransferLine>
    {
        public int Id { get; set; }
    }
}
