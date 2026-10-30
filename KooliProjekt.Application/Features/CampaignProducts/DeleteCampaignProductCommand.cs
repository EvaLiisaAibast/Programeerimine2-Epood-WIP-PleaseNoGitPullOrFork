using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.CampaignProducts
{
    public class DeleteCampaignProductCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
