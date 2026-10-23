using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Notifications
{
    public class GetNotificationQuery : IRequest<OperationResult<NotificationDto>>
    {
        public int Id { get; set; }
    }
}
