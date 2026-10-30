using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Carriers
{
    public class DeleteCarrierCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
