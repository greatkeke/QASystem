using QASystem.Service.SubjectService;
using QASystem.Web.Attributes;
using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class SubjectController : Controller
    {
        private ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        /// <summary>
        /// 所有主题
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [LoginSkip]
        public PartialViewResult List()
        {
            ViewBag.Cates = _subjectService.GetAll();
            return PartialView();
        }
    }
}