using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class GetLoyaltyAccountQuery : IRequest<OperationResult<LoyaltyAccountDto>>
    {
        public int Id { get; set; }
    }
}
