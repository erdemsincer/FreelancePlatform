using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebUI.Areas.Freelancer.Controllers
{
    public class FreelancerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
