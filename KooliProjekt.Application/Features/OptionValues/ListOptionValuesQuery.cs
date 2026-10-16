using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.OptionValues
{
    public class ListOptionValuesQuery : IRequest<IEnumerable<OptionValue>>
    {
    }
}
