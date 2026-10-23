using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class LoyaltyPointsListItemDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int Points { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
