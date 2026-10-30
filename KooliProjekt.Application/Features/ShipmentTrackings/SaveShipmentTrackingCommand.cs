using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class SaveShipmentTrackingCommand : IRequest<OperationResult<int>>
    {
        public ShipmentTrackingDto Data { get; set; }
    }
}
