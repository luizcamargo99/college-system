using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System.Web.Mvc;

namespace MagniUniveristy.Controllers
{
    public class StudentController : BaseController<Student>
    {
        private IStudentService _studentService;

        public StudentController(BaseService<Student> baseService, ValidationViewModel validation, IStudentService studentService) : base(baseService, validation)
        {
            _studentService = studentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudents(string query)
        {
            var model = _studentService.GetStudentsView(query);

            return Json(new { response = model }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            _studentService.EditStudent(student, _validation);

            return Json(new { response = _validation }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveStudent(Student student)
        {
            _studentService.RemoveStudent(student, _validation);

            return Json(new { response = _validation }, JsonRequestBehavior.AllowGet);
        }
    }
}