using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Campaigns
{
    public class ListCampaignsQuery : IRequest<IEnumerable<Campaign>>
    {
    }
}
