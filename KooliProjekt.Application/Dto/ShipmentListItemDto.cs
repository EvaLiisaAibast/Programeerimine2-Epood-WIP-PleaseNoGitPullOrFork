using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ShipmentListItemDto
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public string CarrierName { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public DateTime EstimatedDelivery { get; set; }
    }
}
