using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
