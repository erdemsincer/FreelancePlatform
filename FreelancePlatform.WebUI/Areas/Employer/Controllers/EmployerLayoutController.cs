using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebUI.Areas.Employer.Controllers
{
    public class EmployerLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
