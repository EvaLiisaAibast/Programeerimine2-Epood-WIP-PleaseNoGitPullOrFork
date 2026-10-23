using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int InvoiceAddressId { get; set; }
        public int DeliveryAddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? PaidAt { get; set; }
        public DateTime? SentAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Vat { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public IList<OrderLineDto> Lines { get; set; }

        public OrderDto()
        {
            Lines = new List<OrderLineDto>();
        }
    }
}
