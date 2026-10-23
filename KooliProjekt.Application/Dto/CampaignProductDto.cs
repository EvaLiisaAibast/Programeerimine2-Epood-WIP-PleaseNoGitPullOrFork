using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CampaignProductDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
