using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.ReviewResponses
{
    public class ListReviewResponsesQuery : IRequest<IEnumerable<ReviewResponse>>
    {
    }
}
