using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReturnLines
{
    public class ListReturnLinesQuery : IRequest<IEnumerable<ReturnLine>>
    {
    }
}
