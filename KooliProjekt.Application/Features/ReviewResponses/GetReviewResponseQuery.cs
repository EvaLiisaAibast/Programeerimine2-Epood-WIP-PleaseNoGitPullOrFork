using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class GetReviewResponseQuery : IRequest<ReviewResponse>
    {
        public int Id { get; set; }
    }
}
