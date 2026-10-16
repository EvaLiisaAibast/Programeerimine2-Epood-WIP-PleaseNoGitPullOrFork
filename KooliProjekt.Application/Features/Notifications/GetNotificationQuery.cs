using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Notifications
{
    public class GetNotificationQuery : IRequest<Notification>
    {
        public int Id { get; set; }
    }
}
