using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ProductVideoDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
