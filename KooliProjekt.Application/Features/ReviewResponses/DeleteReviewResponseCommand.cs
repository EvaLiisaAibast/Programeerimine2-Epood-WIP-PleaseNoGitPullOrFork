using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class DeleteReviewResponseCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
