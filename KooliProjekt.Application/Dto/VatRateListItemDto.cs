using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class VatRateListItemDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}
