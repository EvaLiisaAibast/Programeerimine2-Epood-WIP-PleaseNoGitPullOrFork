using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Carriers
{
    public class ListCarriersQuery : IRequest<IEnumerable<Carrier>>
    {
    }
}
