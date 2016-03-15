using System;
using System.Linq;
using System.Web.Mvc;
using QASystem.Web.Models;
using QASystem.Service.AccountService;
using QASystem.Core.Domain;
using QASystem.Web.Helper;
using QASystem.Web.Attributes;

namespace QASystem.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //
        // GET: /Account/Login
        [LoginSkip]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [LoginSkip]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //todo:多次登陆失败，锁定帐号
            if (OperateContext.Current.Login(model))
            {
                //successed
                return RedirectToLocal(returnUrl);
            }
            else
            {
                return View(model);
            }
        }
        /// <summary>
        /// 解析url，并跳转
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                string[] urls = returnUrl.Split('/');
                //todo:带有路由参数的Url
                if (urls.Count() == 2)
                {
                    return RedirectToAction(actionName: urls[1], controllerName: urls[0]);
                }
                else
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Question");
                }
            }
            catch (Exception)
            {
                //解析异常或者Url异常的，都跳转到首页
                return RedirectToAction(actionName: "Index", controllerName: "Question");
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        [LoginSkip]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [LoginSkip]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isSuccessed = _accountService.AddAccount(new User()
                {
                    Email = model.Email,
                    Password = model.Password,
                    CreateDateUtc = DateTime.UtcNow,
                    Username = model.UserName,
                });
                if (isSuccessed)
                {
                    //登陆
                    return Login(new LoginViewModel()
                    {
                        Email = model.Email,
                        Password = model.Password,
                        RememberMe = false
                    }, null);
                }
            }
            // 如果我们进行到这一步时某个地方出错，则重新显示表单
            return View(model);
        }



        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            OperateContext.Current.LoginOff();
            return RedirectToAction(actionName: "Index", controllerName: "Question", routeValues: null);
        }
    }
}