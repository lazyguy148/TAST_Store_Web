using Microsoft.Win32;
using TAST_Store.Models;

namespace TAST_Store.ViewModels
{
    public class ProductManagerViewModel
    {
        public List<Menu>? Menus { get; set; }
        public Product ?Product { get; set; }

        public List<Catology> Cats { get; set; }

        public ProductManagerViewModel()
        {
            Product = new Product();
        }
    }
}
