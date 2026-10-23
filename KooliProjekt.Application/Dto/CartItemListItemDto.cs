using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CartItemListItemDto
    {
        public int Id { get; set; }
        public string VariantCode { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
