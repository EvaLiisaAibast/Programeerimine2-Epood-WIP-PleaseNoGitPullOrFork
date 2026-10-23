using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Carriers
{
    public class GetCarrierQuery : IRequest<OperationResult<CarrierDto>>
    {
        public int Id { get; set; }
    }
}
