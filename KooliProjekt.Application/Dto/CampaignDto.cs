using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public IList<CampaignProductDto> Products { get; set; }

        public CampaignDto()
        {
            Products = new List<CampaignProductDto>();
        }
    }
}
