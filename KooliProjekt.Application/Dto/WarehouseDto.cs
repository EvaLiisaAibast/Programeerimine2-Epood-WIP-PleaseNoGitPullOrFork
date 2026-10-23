using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class WarehouseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public string AddressName { get; set; }
    }
}
