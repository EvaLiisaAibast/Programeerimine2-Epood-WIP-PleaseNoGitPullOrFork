using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Reviews
{
    public class ListReviewsQuery : IRequest<IEnumerable<Review>>
    {
    }
}
