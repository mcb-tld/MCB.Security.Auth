using System;
using System.Collections.Generic;
using System.Text;

namespace MCB.Security.Infrastructure.Data.Entities
{
    public class UserRole : BaseEntity
    {
        public int Guid { get; set; }
        public int UserGuid { get; set; }
        public string RoleName { get; set; }
    }
}
