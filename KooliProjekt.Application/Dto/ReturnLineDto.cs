using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class ReturnLineDto
    {
        public int Id { get; set; }
        public int ReturnRequestId { get; set; }
        public int OrderLineId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; }
    }
}
