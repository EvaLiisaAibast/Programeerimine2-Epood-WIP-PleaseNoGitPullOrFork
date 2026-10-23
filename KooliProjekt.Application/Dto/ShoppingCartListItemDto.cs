using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ShoppingCartListItemDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int ItemCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
