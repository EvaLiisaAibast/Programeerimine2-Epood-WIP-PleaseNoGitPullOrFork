using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class GiftCardListItemDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal Balance { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
