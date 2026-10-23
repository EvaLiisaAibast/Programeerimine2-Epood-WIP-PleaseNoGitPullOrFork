using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class VariantOptionDto
    {
        public int Id { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public int OptionValueId { get; set; }
        public string OptionValueName { get; set; }
    }
}
