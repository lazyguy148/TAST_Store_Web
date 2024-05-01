using System;
using System.Collections.Generic;

namespace TAST_Store.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Carts = new HashSet<Cart>();
        }

        public int IdUsers { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Permission { get; set; }
        public string? Meta { get; set; }
        public int? Order { get; set; }
        public string? Link { get; set; }
        public int? Hide { get; set; }

        public virtual Permission? PermissionNavigation { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
