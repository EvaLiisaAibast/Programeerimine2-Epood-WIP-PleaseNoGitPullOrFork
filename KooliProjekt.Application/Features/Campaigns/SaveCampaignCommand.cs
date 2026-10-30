using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class SaveCampaignCommand : IRequest<OperationResult<int>>
    {
        public CampaignDto Data { get; set; }
    }
}
