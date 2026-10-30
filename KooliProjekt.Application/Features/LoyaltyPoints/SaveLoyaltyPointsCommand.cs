using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class SaveLoyaltyPointsCommand : IRequest<OperationResult<int>>
    {
        public LoyaltyPointsDto Data { get; set; }
    }
}
