using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PaymentListItemDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string Method { get; set; }
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
