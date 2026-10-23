using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class RefundDto
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
