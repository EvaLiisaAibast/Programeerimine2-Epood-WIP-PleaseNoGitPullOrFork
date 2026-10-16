using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class ListCampaignProductsQuery : IRequest<IEnumerable<CampaignProduct>>
    {
    }
}
