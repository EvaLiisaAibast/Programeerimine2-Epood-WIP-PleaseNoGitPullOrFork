using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Products
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
