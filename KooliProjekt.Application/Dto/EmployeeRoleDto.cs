using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class EmployeeRoleDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
    }
}
