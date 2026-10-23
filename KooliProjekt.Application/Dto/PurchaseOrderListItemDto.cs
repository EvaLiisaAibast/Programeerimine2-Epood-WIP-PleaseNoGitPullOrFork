using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PurchaseOrderListItemDto
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime ExpectedAt { get; set; }
        public string Status { get; set; }
    }
}
