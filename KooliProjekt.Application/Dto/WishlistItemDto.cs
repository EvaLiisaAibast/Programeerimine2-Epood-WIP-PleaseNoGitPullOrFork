using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WishlistItemDto
    {
        public int Id { get; set; }
        public int WishlistId { get; set; }
        public string WishlistName { get; set; }
        public int VariantId { get; set; }
        public string VariantCode { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
