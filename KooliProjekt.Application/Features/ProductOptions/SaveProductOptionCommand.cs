using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class SaveProductOptionCommand : IRequest<OperationResult<int>>
    {
        public ProductOptionDto Data { get; set; }
    }
}
