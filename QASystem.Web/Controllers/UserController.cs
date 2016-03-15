using QASystem.Service.UserService;
using QASystem.Web.Attributes;
using QASystem.Web.Helper;
using QASystem.Web.Models;
using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 用户信息展示
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [LoginSkip]
        public PartialViewResult UserView()
        {
            //获取当前用户
            var usr = OperateContext.Current.LoginUser;
            if (usr != null)
            {
                var userVM = new UserViewModel();
                //生成UserViewModel
                userVM.Id = usr.Id;
                userVM.ImgUrl = usr.ImgUrl;
                userVM.Username = usr.Username;
                userVM.QuestionCollectionCount = _userService.QuestionCollectionCount(usr.Id);
                userVM.TopicCollectionCount = _userService.TopicCollectionCount(usr.Id);
                userVM.UserCollectionCount = _userService.UserCollectionCount(usr.Id);
                ViewBag.UserViewModel = userVM;
            }
            return PartialView();
        }
    }
}