using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OrderLineDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Amount { get; set; }
    }
}
