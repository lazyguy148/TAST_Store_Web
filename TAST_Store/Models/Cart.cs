using System;
using System.Collections.Generic;

namespace TAST_Store.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartDetails = new HashSet<CartDetail>();
        }

        public int IdCart { get; set; }
        public DateTime? Datebegin { get; set; }
        public string? Meta { get; set; }
        public int? Order { get; set; }
        public string? Link { get; set; }
        public int? Hide { get; set; }
        public int? IdUsers { get; set; }

        public virtual User? IdUsersNavigation { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}
