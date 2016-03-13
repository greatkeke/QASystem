using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult UserView()
        {
            return PartialView();
        }
    }
}