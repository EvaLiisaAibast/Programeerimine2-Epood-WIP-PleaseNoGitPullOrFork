using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Notifications
{
    public class DeleteNotificationCommand : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }
}
