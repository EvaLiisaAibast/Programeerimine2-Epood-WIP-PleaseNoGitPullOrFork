using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Url { get; set; }
        public string AltText { get; set; }
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
    }
}
