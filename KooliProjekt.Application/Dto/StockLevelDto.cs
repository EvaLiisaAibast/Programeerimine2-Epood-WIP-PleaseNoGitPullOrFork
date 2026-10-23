using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class StockLevelDto
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public int Quantity { get; set; }
        public int Reserved { get; set; }
        public int MinimumStock { get; set; }
    }
}
