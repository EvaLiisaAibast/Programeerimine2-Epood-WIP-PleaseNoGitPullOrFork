using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Addresses
{
    public class GetAddressQuery : IRequest<OperationResult<AddressDto>>
    {
        public int Id { get; set; }
    }
}
