using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class SaveLoyaltyAccountCommand : IRequest<OperationResult<int>>
    {
        public LoyaltyAccountDto Data { get; set; }
    }
}
