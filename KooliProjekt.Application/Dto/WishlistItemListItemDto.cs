using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WishlistItemListItemDto
    {
        public int Id { get; set; }
        public string WishlistName { get; set; }
        public string VariantCode { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
