using System;
using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class AuditLogListItemDto
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string ObjectType { get; set; }
        public int ObjectId { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
