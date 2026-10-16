using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetProductImageQuery : IRequest<ProductImage>
    {
        public int Id { get; set; }
    }
}
