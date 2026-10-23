using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Price { get; set; }
        public decimal WeightKg { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public IList<ProductImageDto> Images { get; set; }
        public IList<ProductVariantDto> Variants { get; set; }

        public ProductDto()
        {
            Images = new List<ProductImageDto>();
            Variants = new List<ProductVariantDto>();
        }
    }
}
