using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WarehouseTransferLineDto
    {
        public int Id { get; set; }
        public int TransferId { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public int Quantity { get; set; }
    }
}
