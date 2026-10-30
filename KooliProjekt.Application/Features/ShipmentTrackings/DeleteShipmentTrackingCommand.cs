using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ShipmentTrackings
{
    public class DeleteShipmentTrackingCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
