using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class GetLoyaltyPointsQuery : IRequest<OperationResult<LoyaltyPointsDto>>
    {
        public int Id { get; set; }
    }
}
