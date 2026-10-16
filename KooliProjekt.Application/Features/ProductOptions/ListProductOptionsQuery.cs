using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductOptions
{
    public class ListProductOptionsQuery : IRequest<IEnumerable<ProductOption>>
    {
    }
}
