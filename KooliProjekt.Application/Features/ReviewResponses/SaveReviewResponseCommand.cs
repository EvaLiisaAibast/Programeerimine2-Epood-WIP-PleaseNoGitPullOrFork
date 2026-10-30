using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class SaveReviewResponseCommand : IRequest<OperationResult<int>>
    {
        public ReviewResponseDto Data { get; set; }
    }
}
