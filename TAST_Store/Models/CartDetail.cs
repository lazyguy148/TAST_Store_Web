using System;
using System.Collections.Generic;

namespace TAST_Store.Models
{
    public partial class CartDetail
    {
        public int IdCd { get; set; }
        public int? SoldNum { get; set; }
        public string? Meta { get; set; }
        public int? Order { get; set; }
        public string? Link { get; set; }
        public int? Hide { get; set; }
        public int? IdCart { get; set; }
        public int? IdPro { get; set; }

        public virtual Cart? IdCartNavigation { get; set; }
        public virtual Product? IdProNavigation { get; set; }
    }
}
