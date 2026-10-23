using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class GetProductOptionQuery : IRequest<OperationResult<ProductOptionDto>>
    {
        public int Id { get; set; }
    }
}
