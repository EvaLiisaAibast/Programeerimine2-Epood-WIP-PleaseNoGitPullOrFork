using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReviewImages
{
    public class ListReviewImagesQuery : IRequest<IEnumerable<ReviewImage>>
    {
    }
}
