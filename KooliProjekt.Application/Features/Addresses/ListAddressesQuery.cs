using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Addresses
{
    public class ListAddressesQuery : IRequest<IEnumerable<Address>>
    {
    }
}
