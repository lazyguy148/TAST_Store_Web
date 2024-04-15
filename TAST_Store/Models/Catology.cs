using System;
using System.Collections.Generic;

namespace TAST_Store.Models
{
    public partial class Catology
    {
        public Catology()
        {
            Products = new HashSet<Product>();
        }

        public int IdCat { get; set; }
        public string? NameCat { get; set; }
        public string? Meta { get; set; }
        public int? Order { get; set; }
        public string? Link { get; set; }
        public int? Hide { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
