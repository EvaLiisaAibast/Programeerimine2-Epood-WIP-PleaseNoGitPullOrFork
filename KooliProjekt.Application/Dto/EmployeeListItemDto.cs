using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class EmployeeListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
