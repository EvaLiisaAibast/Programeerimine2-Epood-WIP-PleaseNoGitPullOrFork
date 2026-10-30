using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Carriers
{
    public class SaveCarrierCommand : IRequest<OperationResult<int>>
    {
        public CarrierDto Data { get; set; }
    }
}
