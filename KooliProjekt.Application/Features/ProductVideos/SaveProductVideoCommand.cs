using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class SaveProductVideoCommand : IRequest<OperationResult<int>>
    {
        public ProductVideoDto Data { get; set; }
    }
}
