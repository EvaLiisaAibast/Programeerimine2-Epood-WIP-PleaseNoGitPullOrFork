using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CouponListItemDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CampaignName { get; set; }
        public int UsedCount { get; set; }
        public int UsageLimit { get; set; }
    }
}
