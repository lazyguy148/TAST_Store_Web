using System;
using System.Collections.Generic;

namespace TAST_Store.Models
{
    public partial class Menu
    {
        public int IdMenu { get; set; }
        public string? Title { get; set; }
        public DateTime? Datebegin { get; set; }
        public string? Meta { get; set; }
        public int? Order { get; set; }
        public string? Link { get; set; }
        public int Hide { get; set; }
    }
}
