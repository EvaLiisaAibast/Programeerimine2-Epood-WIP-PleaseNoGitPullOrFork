using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReviewImages
{
    public class GetReviewImageQuery : IRequest<ReviewImage>
    {
        public int Id { get; set; }
    }
}
