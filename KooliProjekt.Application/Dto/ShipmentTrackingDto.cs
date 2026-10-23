using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ShipmentTrackingDto
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
