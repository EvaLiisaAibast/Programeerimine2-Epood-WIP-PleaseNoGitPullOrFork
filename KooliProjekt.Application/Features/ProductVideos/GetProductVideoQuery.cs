using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class GetProductVideoQuery : IRequest<OperationResult<ProductVideoDto>>
    {
        public int Id { get; set; }
    }
}
