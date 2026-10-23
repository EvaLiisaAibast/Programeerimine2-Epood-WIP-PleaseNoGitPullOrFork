using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class SupportTicketListItemDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Subject { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
