using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Addresses
{
    public class DeleteAddressCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
