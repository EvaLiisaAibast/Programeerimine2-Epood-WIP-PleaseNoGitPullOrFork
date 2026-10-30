using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class DeleteLoyaltyAccountCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
