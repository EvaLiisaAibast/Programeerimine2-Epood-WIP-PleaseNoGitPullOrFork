using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class GetShipmentTrackingQuery : IRequest<OperationResult<ShipmentTrackingDto>>
    {
        public int Id { get; set; }
    }
}
