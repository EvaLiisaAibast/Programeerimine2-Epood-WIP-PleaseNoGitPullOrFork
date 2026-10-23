using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CampaignProductListItemDto
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string ProductName { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
