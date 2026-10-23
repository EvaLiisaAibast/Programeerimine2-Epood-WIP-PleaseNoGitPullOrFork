using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CampaignListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
