using KooliProjekt.Application.Data;
using MediatR;
using LoyaltyPointsEntity = KooliProjekt.Application.Data.LoyaltyPoints;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class GetLoyaltyPointsQuery : IRequest<LoyaltyPointsEntity>
    {
        public int Id { get; set; }
    }
}
