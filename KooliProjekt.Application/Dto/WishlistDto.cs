using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WishlistDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<WishlistItemDto> Items { get; set; }

        public WishlistDto()
        {
            Items = new List<WishlistItemDto>();
        }
    }
}
