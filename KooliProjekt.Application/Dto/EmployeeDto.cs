using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
