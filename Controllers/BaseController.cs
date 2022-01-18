using MagniUniveristy.Models.ViewModel;
using System.Web.Mvc;

namespace MagniUniveristy.Controllers
{
    public class BaseController<T> : Controller where T : class
    {
        private BaseService<T> _baseService;
        protected ValidationViewModel _validation;

        public BaseController(BaseService<T> baseService, ValidationViewModel validation)
        {
            _baseService = baseService;
            _validation = validation;
        }

        [HttpPost]
        public ActionResult Create(T item)
        {
            _baseService.Add(item, _validation);

            return Json(new { response = _validation }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(T item)
        {
            _baseService.Edit(item, _validation);

            return Json(new { response = _validation }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(T item)
        {
            _baseService.Remove(item, _validation);

            return Json(new { response = _validation }, JsonRequestBehavior.AllowGet);
        }
    }
}