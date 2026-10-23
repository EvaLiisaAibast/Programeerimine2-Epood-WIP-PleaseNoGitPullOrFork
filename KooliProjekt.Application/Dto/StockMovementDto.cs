using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class StockMovementDto
    {
        public int Id { get; set; }
        public int StockLevelId { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
