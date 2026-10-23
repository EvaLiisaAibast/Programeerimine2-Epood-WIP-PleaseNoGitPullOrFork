using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class NotificationListItemDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ReadAt { get; set; }
    }
}
