using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Reviews
{
    public class GetReviewQuery : IRequest<Review>
    {
        public int Id { get; set; }
    }
}
