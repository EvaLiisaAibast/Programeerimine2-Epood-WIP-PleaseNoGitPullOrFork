using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReviewListItemDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
