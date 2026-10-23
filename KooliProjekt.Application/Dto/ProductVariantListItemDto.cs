using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductVariantListItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
    }
}
