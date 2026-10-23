using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ExchangeRateDto
    {
        public int Id { get; set; }
        public int FromCurrencyId { get; set; }
        public string FromCurrencyCode { get; set; }
        public int ToCurrencyId { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
