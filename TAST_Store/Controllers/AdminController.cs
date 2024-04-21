using Microsoft.AspNetCore.Mvc;

namespace TAST_Store.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> _MenuPartial()
        {
            return PartialView();
        }
    }
}
