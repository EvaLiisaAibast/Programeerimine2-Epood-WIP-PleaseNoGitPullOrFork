using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OrderListItemDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
