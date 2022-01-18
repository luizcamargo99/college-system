using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System.Web.Mvc;

namespace MagniUniveristy.Controllers
{
    public class TeacherController : BaseController<Teacher>
    {
        private ITeacherService _teacherService;

        public TeacherController(BaseService<Teacher> baseService, ValidationViewModel validation, ITeacherService teacherService) : base(baseService, validation)
        {
            _teacherService = teacherService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTeachers(string query)
        {
            var model = _teacherService.GetTeachers(query);

            return Json(new { response = model }, JsonRequestBehavior.AllowGet);
        }
    }
}