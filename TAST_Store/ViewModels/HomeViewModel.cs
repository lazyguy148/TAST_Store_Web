using TAST_Store.Models;

namespace TAST_Store.ViewModels
{
    public class HomeViewModel
    {
        public List<Menu> ?Menus { get; set; }
        public List<Blog> ?Blogs { get; set; }
        public List<Slider> ?Sliders { get; set; }
        public List<Product> ?MaleProds { get; set; }
        public List<Product> ?FemaleProds { get; set; }

        public Catology ?MaleCateProds { get; set; }
        public Catology ?FemaleCateProds { get; set; }

        public List<Product>? MalePantProds { get; set; }
        public List<Product>? FemalePantProds { get; set; }
        public Catology ?MalePantCateProds { get; set; }
        public Catology ?FemalePantCateProds { get; set; }
    }
}
