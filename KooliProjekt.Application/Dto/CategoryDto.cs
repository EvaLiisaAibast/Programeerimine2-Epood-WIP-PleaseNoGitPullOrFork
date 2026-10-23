using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
