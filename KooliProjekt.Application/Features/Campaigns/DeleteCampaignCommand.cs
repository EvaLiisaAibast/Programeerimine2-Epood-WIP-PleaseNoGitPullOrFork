using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Campaigns
{
    public class DeleteCampaignCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
