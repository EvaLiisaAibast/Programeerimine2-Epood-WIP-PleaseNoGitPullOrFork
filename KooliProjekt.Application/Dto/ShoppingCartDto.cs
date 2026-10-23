using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<CartItemDto> Items { get; set; }

        public ShoppingCartDto()
        {
            Items = new List<CartItemDto>();
        }
    }
}
