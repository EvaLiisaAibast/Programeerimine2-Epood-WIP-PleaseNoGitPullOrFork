using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductVariants
{
    public class ListProductVariantsQuery : IRequest<IEnumerable<ProductVariant>>
    {
    }
}
