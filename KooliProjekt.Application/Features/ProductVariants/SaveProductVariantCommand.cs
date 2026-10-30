using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductVariants
{
    public class SaveProductVariantCommand : IRequest<OperationResult<int>>
    {
        public ProductVariantDto Data { get; set; }
    }
}
