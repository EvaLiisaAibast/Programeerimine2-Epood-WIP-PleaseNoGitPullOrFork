using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class DeleteReviewImageCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
