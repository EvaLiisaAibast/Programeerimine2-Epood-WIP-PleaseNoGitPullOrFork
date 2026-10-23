using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PriceHistoryListItemDto
    {
        public int Id { get; set; }
        public string VariantCode { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
