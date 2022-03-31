using System;
using System.Collections.Generic;

#nullable disable

namespace _2RPNET_API.Domains
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int IdRoles { get; set; }
        public string TitleRoles { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
