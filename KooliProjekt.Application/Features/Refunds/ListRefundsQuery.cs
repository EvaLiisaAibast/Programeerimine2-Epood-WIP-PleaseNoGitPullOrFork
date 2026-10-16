using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Refunds
{
    public class ListRefundsQuery : IRequest<IEnumerable<Refund>>
    {
    }
}
