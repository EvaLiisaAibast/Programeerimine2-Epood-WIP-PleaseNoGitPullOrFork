using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OrderStatusHistoryDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int ChangedBy { get; set; }
        public string ChangedByName { get; set; }
    }
}
