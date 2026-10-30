using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ProductOptions
{
    public class DeleteProductOptionCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
