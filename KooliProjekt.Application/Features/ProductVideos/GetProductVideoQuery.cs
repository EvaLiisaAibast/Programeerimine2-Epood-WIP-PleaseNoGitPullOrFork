using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductVideos
{
    public class GetProductVideoQuery : IRequest<ProductVideo>
    {
        public int Id { get; set; }
    }
}
