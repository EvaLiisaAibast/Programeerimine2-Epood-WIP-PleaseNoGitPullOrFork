using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Shipments
{
    public class SaveShipmentCommand : IRequest<OperationResult<int>>
    {
        public ShipmentDto Data { get; set; }
    }
}
