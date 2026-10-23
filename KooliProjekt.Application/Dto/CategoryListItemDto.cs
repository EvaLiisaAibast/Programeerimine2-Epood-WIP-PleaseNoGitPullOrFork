using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CategoryListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ParentCategoryName { get; set; }
    }
}
