using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string ImageUrl { get; set; }
    }
}
