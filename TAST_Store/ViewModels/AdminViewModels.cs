using TAST_Store.Models;

namespace TAST_Store.ViewModels
{
    public class AdminViewModels
    {
        public List<Menu> Menus { get; set; }

        public User Register { get; set; }
        public AdminViewModels()
        {
            Register = new User();
        }
    }
}
