using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Shipments
{
    public class GetShipmentQuery : IRequest<Shipment>
    {
        public int Id { get; set; }
    }
}
