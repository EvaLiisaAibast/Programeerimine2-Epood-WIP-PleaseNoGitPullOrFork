using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class AuditLogDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string ObjectType { get; set; }
        public int ObjectId { get; set; }
        public string Action { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
