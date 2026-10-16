using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductVariants
{
    public class GetProductVariantQuery : IRequest<ProductVariant>
    {
        public int Id { get; set; }
    }
}
