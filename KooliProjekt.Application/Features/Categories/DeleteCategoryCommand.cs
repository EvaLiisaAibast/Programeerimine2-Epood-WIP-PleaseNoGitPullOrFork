using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Categories
{
    public class DeleteCategoryCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
