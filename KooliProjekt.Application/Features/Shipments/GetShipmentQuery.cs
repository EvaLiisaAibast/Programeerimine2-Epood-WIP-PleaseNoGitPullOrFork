using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Shipments
{
    public class GetShipmentQuery : IRequest<OperationResult<ShipmentDto>>
    {
        public int Id { get; set; }
    }
}
