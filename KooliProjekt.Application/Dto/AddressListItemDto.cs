using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class AddressListItemDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public bool IsDefault { get; set; }
    }
}
