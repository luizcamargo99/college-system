using MagniUniveristy.Models.Interface;
using System.Web.Mvc;

namespace MagniUniveristy.Controllers
{
    public class HomeController : Controller    
    {
        private IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetInfoHome()
        {
            var model = _homeService.GetInfoHome();

            return Json(new { response = model }, JsonRequestBehavior.AllowGet);
        }
    }
}