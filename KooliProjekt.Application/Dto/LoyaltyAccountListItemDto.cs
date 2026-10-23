using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class LoyaltyAccountListItemDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int Balance { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
