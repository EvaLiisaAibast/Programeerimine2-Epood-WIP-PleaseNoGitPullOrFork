using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductImageListItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public bool IsMain { get; set; }
    }
}
