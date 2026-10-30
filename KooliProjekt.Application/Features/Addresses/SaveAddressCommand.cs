using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Addresses
{
    public class SaveAddressCommand : IRequest<OperationResult<int>>
    {
        public AddressDto Data { get; set; }
    }
}
