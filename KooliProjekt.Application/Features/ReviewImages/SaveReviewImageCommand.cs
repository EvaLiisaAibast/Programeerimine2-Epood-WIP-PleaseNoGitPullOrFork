using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.ReviewImages
{
    public class SaveReviewImageCommand : IRequest<OperationResult<int>>
    {
        public ReviewImageDto Data { get; set; }
    }
}
