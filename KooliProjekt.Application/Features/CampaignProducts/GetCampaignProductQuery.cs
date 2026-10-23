using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class GetCampaignProductQuery : IRequest<OperationResult<CampaignProductDto>>
    {
        public int Id { get; set; }
    }
}
