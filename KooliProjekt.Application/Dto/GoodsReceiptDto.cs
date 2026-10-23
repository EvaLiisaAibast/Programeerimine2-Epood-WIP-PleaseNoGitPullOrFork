using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class GoodsReceiptDto
    {
        public int Id { get; set; }
        public int PurchaseOrderLineId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
