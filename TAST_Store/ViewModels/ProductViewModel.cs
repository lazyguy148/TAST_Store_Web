using TAST_Store.Models;

namespace TAST_Store.ViewModels
{
    public class ProductViewModel
    {
        public List<Menu> Menus { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Product> Prods { get; set; }

        public String cateName { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }

        
    }
}
