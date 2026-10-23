using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PurchaseOrderLineDto
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public int OrderedQuantity { get; set; }
        public int ReceivedQuantity { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}
