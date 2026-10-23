using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class GetReviewImageQuery : IRequest<OperationResult<ReviewImageDto>>
    {
        public int Id { get; set; }
    }
}
