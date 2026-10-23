using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class GetProductImageQuery : IRequest<OperationResult<ProductImageDto>>
    {
        public int Id { get; set; }
    }
}
