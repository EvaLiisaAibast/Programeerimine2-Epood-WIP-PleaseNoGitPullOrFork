using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class GetCampaignQuery : IRequest<OperationResult<CampaignDto>>
    {
        public int Id { get; set; }
    }
}
