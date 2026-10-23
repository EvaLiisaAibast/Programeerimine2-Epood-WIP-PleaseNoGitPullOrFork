using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class StockLevelListItemDto
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public string VariantCode { get; set; }
        public int Quantity { get; set; }
        public int Reserved { get; set; }
        public int MinimumStock { get; set; }
    }
}
