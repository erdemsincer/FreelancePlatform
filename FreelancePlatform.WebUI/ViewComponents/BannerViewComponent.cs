using Microsoft.AspNetCore.Mvc;

namespace FreelancePlatform.WebUI.ViewComponents
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.Title = "Freelance Platform’a Hoşgeldiniz";
            ViewBag.SubTitle = "Projelerinizi en iyi freelancerlarla buluşturun.";
            return View();
        }
    }
}
