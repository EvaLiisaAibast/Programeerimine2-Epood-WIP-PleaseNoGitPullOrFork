using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Products
{
    public class DeleteProductCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
