using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class AddressDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Apartment { get; set; }
        public bool IsDefault { get; set; }
    }
}
