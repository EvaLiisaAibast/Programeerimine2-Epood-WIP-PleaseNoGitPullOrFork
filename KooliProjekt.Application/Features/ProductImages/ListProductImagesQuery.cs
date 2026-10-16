using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductImages
{
    public class ListProductImagesQuery : IRequest<IEnumerable<ProductImage>>
    {
    }
}
