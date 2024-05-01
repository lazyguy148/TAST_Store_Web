using System;
using System.Collections.Generic;

namespace TAST_Store.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Users = new HashSet<User>();
        }

        public int IdPermission { get; set; }
        public string? Permission1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
