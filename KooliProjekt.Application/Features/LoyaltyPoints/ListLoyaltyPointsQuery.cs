using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;
using LoyaltyPointsEntity = KooliProjekt.Application.Data.LoyaltyPoints;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class ListLoyaltyPointsQuery : IRequest<IEnumerable<LoyaltyPointsEntity>>
    {
    }
}
