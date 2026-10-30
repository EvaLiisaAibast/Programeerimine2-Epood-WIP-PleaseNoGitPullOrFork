using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Shipments
{
    public class DeleteShipmentCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
