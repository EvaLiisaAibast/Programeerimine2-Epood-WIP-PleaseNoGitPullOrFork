using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyPoints
{
    public class DeleteLoyaltyPointsCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
