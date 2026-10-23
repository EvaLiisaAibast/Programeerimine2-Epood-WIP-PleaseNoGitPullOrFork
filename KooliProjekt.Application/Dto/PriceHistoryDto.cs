using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class PriceHistoryDto
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public decimal CurrentPrice { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
