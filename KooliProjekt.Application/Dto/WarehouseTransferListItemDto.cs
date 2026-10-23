using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WarehouseTransferListItemDto
    {
        public int Id { get; set; }
        public string FromWarehouseName { get; set; }
        public string ToWarehouseName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
