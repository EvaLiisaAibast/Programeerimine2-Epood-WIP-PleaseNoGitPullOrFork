using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CouponDto
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public string Code { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public decimal MinimumOrderAmount { get; set; }
    }
}
