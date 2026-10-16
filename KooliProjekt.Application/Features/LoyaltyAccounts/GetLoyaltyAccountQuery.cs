using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class GetLoyaltyAccountQuery : IRequest<LoyaltyAccount>
    {
        public int Id { get; set; }
    }
}
