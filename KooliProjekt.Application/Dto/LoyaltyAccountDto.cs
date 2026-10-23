using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class LoyaltyAccountDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
