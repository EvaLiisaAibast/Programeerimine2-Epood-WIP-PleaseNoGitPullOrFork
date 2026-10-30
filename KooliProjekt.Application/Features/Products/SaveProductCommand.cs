using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Products
{
    public class SaveProductCommand : IRequest<OperationResult<int>>
    {
        public ProductDto Data { get; set; }
    }
}
