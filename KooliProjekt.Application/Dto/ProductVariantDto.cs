using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductVariantDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal WeightKg { get; set; }
        public string Status { get; set; }
    }
}
