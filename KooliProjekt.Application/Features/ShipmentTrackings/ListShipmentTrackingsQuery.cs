using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class ListShipmentTrackingsQuery : IRequest<IEnumerable<ShipmentTracking>>
    {
    }
}
