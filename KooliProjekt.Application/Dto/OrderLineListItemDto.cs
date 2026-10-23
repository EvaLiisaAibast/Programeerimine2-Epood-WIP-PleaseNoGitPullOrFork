using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OrderLineListItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
