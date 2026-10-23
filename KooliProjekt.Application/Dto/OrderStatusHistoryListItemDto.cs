using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OrderStatusHistoryListItemDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
