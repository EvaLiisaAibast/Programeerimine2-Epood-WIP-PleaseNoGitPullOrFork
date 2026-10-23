using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class GetReviewResponseQuery : IRequest<OperationResult<ReviewResponseDto>>
    {
        public int Id { get; set; }
    }
}
