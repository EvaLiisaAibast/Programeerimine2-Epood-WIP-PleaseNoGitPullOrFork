using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CustomerListItemDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
