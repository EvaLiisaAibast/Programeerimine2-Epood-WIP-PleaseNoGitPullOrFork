using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReturnRequests
{
    public class ListReturnRequestsQuery : IRequest<IEnumerable<ReturnRequest>>
    {
    }
}
