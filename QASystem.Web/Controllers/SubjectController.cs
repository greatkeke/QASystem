using QASystem.Service.SubjectService;
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

        [ChildActionOnly]
        public PartialViewResult List()
        {
            //获取所有的分类
            ViewBag.Cates = _subjectService.GetAll();
            return PartialView();
        }
    }
}