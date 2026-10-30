using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Reviews
{
    public class DeleteReviewCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
