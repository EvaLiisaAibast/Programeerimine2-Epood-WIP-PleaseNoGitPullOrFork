using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class TicketMessageListItemDto
    {
        public int Id { get; set; }
        public string TicketSubject { get; set; }
        public string SenderType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
