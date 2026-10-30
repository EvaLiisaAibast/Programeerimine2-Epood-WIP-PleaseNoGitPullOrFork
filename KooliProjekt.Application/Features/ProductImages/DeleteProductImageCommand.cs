using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductImages
{
    public class DeleteProductImageCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
