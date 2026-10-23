using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WarehouseTransferDto
    {
        public int Id { get; set; }
        public int FromWarehouseId { get; set; }
        public string FromWarehouseName { get; set; }
        public int ToWarehouseId { get; set; }
        public string ToWarehouseName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
    }
}
