using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.VariantOptions
{
    public class ListVariantOptionsQuery : IRequest<IEnumerable<VariantOption>>
    {
    }
}
