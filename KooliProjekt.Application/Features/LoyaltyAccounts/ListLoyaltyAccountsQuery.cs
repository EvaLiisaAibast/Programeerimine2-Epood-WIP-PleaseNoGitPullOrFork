using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.LoyaltyAccounts
{
    public class ListLoyaltyAccountsQuery : IRequest<IEnumerable<LoyaltyAccount>>
    {
    }
}
