using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CustomerGroupListItemDto
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
