using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
