using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
        public string TransactionReference { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
