using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ShipmentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime EstimatedDelivery { get; set; }
        public DateTime DeliveredAt { get; set; }
        public string Status { get; set; }
        public IList<ShipmentTrackingDto> Trackings { get; set; }

        public ShipmentDto()
        {
            Trackings = new List<ShipmentTrackingDto>();
        }
    }
}
