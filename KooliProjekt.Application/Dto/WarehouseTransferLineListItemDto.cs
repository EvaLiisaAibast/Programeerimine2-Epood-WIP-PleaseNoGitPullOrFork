using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WarehouseTransferLineListItemDto
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public string VariantCode { get; set; }
        public int Quantity { get; set; }
    }
}
