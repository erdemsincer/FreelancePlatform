using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
          
            return View();
        }
    }
}
