using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PurchaseOrderDto
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ExpectedAt { get; set; }
        public string Status { get; set; }
    }
}
