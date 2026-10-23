using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ExchangeRateListItemDto
    {
        public int Id { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
