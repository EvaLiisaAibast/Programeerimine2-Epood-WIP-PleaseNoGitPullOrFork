using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class GetProductVariantQuery : IRequest<OperationResult<ProductVariantDto>>
    {
        public int Id { get; set; }
    }
}
