using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductVideos
{
    public class DeleteProductVideoCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
