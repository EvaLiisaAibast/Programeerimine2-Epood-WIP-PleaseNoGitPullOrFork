using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class VatRateDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
