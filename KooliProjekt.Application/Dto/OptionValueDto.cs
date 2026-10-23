using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OptionValueDto
    {
        public int Id { get; set; }
        public int ProductOptionId { get; set; }
        public string ProductOptionName { get; set; }
        public string Value { get; set; }
    }
}
