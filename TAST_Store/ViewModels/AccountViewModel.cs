using TAST_Store.Models;

namespace TAST_Store.ViewModels
{
    public class AccountViewModel
    {
        public List<Menu> ?Menus { get; set; }
        public List<User> ?Users { get; set; }

        public List<Permission> ?Permissions { get; set; }
        public User Acc { get; set; }
        public AccountViewModel()
        {
            Acc = new User();
        }
    }
}
