using MagniUniveristy.Models;
using MagniUniveristy.Models.Interface;
using MagniUniveristy.Models.ViewModel;
using System.Web.Mvc;

namespace MagniUniveristy.Controllers
{
    public class SubjectController : BaseController<Subject>
    {
        private ISubjectService _subjectService;

        public SubjectController(BaseService<Subject> baseService, ValidationViewModel validation, ISubjectService subjectService) : base(baseService, validation)
        {
            _subjectService = subjectService;
        }   

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSubjects(string query)
        {
            var model = _subjectService.GetSubjects(query);

            return Json(new { response = model }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInfoModal()
        {
            var model = _subjectService.GetInfoModal();

            return Json(new { response = model }, JsonRequestBehavior.AllowGet);
        }
    }
}