using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Campaigns
{
    public class GetCampaignQuery : IRequest<Campaign>
    {
        public int Id { get; set; }
    }
}
