using TAST_Store.Models;

namespace TAST_Store.ViewModels
{
    public class BlogManagerViewModel
    {
        public List<Menu> ?Menus { get; set; }
        public List<Blog> ?Blogs { get; set; }
        public List<User>? Users { get; set; }
    }
}
