using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System.Web.Mvc;

namespace MagniUniveristy.Controllers
{
    public class CourseController : BaseController<Course> 
    {
        private ICourseService _courseService;

        public CourseController(BaseService<Course> baseService, ValidationViewModel validation, ICourseService courseService) : base (baseService, validation)
        {
            _courseService = courseService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCourses(string query)
        {
            var model = _courseService.GetCoursesView(query);

            return Json(new { response = model }, JsonRequestBehavior.AllowGet);
        }        
    }
}