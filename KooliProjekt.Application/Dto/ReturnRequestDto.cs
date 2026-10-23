using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReturnRequestDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
