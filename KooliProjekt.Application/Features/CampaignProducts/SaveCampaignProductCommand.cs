using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class SaveCampaignProductCommand : IRequest<OperationResult<int>>
    {
        public CampaignProductDto Data { get; set; }
    }
}
