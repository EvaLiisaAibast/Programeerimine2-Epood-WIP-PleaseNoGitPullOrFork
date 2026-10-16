using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductVideos
{
    public class ListProductVideosQuery : IRequest<IEnumerable<ProductVideo>>
    {
    }
}
