using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class TicketMessageDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string TicketSubject { get; set; }
        public string SenderType { get; set; }
        public int SenderId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
