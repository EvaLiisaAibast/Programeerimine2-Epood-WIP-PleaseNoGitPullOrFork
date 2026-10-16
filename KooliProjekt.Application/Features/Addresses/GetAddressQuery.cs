using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Addresses
{
    public class GetAddressQuery : IRequest<Address>
    {
        public int Id { get; set; }
    }
}
