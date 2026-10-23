using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Reviews
{
    public class GetReviewQuery : IRequest<OperationResult<ReviewDto>>
    {
        public int Id { get; set; }
    }
}
