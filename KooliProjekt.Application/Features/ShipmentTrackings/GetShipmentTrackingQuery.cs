using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class GetShipmentTrackingQuery : IRequest<ShipmentTracking>
    {
        public int Id { get; set; }
    }
}
