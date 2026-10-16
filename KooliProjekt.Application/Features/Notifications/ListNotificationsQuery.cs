using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;


namespace KooliProjekt.Application.Features.Notifications
{
    public class ListNotificationsQuery : IRequest<IEnumerable<Notification>>
    {
    }
}
