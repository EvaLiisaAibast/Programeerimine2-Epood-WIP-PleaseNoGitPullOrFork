using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Notifications
{
    public class SaveNotificationCommand : IRequest<OperationResult<int>>
    {
        public NotificationDto Data { get; set; }
    }
}
