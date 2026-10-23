using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class SupportTicketDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int ResponsibleEmployeeId { get; set; }
        public string ResponsibleEmployeeName { get; set; }
        public string Subject { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ClosedAt { get; set; }
        public IList<TicketMessageDto> Messages { get; set; }

        public SupportTicketDto()
        {
            Messages = new List<TicketMessageDto>();
        }
    }
}
