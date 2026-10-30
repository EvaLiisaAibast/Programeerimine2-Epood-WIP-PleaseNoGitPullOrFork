using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class SaveProductImageCommand : IRequest<OperationResult<int>>
    {
        public ProductImageDto Data { get; set; }
    }
}
