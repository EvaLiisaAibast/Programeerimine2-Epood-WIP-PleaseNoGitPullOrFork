using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class GetCampaignProductQuery : IRequest<CampaignProduct>
    {
        public int Id { get; set; }
    }
}
