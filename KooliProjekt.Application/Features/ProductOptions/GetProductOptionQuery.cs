using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ProductOptions
{
    public class GetProductOptionQuery : IRequest<ProductOption>
    {
        public int Id { get; set; }
    }
}
