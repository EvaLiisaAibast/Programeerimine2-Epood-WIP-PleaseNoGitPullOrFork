using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReviewResponseListItemDto
    {
        public int Id { get; set; }
        public string ReviewTitle { get; set; }
        public string EmployeeName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
