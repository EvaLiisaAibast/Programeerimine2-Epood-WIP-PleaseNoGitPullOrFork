using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Shipments
{
    public class ListShipmentsQuery : IRequest<IEnumerable<Shipment>>
    {
    }
}
