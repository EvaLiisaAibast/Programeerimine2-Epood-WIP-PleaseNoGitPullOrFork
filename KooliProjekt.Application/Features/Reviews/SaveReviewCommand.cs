using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Reviews
{
    public class SaveReviewCommand : IRequest<OperationResult<int>>
    {
        public ReviewDto Data { get; set; }
    }
}
