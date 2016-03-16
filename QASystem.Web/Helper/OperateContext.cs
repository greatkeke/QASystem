using Autofac.Integration.Mvc;
using QASystem.Core.Domain;
using QASystem.Service.AccountService;
using QASystem.Web.Models;
using System;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace QASystem.Web.Helper
{
    public class OperateContext
    {
        public const string CookiePath = "/";
        public const string InfoKey = "ainfo";

        private HttpSessionState Session = HttpContext.Current.Session;
        private HttpRequest Request = HttpContext.Current.Request;
        private HttpResponse Response = HttpContext.Current.Response;

        private IAccountService _accountService;

        public OperateContext()
        {
            var autoFacDR = DependencyResolver.Current as AutofacDependencyResolver;
            _accountService = autoFacDR.GetService<IAccountService>();
        }

        /// <summary>
        /// 获取当前 操作上下文 (为每个处理浏览器请求的服务器线程 单独创建 操作上下文)
        /// </summary>
        public static OperateContext Current
        {
            get
            {
                OperateContext oContext = CallContext.GetData(typeof(OperateContext).Name) as OperateContext;
                if (oContext == null)
                {
                    oContext = new OperateContext();
                    CallContext.SetData(typeof(OperateContext).Name, oContext);
                }
                return oContext;
            }
        }

        // <summary>
        /// 当前用户对象
        /// </summary>
        public User LoginUser
        {
            get
            {
                return Session[InfoKey] as User;
            }
            set
            {
                Session[InfoKey] = value;
            }
        }

        public bool Login(LoginViewModel model)
        {
            //到业务成查询
            User usr = _accountService.Login(model.Email, model.Password);
            if (usr != null)
            {
                //保存 用户数据(Session or Cookie)
                LoginUser = usr;
                //如果选择了复选框，则要使用cookie保存数据
                if (model.RememberMe)
                {
                    //将用户id加密成字符串
                    string strCookieValue = SecurityHelper.EncryptUserInfo(usr.Id.ToString());
                    //创建cookie
                    HttpCookie cookie = new HttpCookie(InfoKey, strCookieValue);
                    cookie.Expires = DateTime.Now.AddDays(1);
                    cookie.Path = CookiePath;
                    Response.Cookies.Add(cookie);
                }
                return true;
            }
            return false;
        }

        public bool IsLogin()
        {
            //1.验证用户是否登陆(Session && Cookie)
            if (Session[InfoKey] == null)
            {
                if (Request.Cookies[InfoKey] == null)
                {
                    //重新登陆，内部已经调用了 Response.End(),后面的代码都不执行了！ (注意：如果Ajax请求，此处不合适！)
                    //filterContext.HttpContext.Response.Redirect("/admin/admin/login");
                    return false;
                }
                else//如果有cookie则从cookie中获取用户id并查询相关数据存入 Session
                {
                    string strUserInfo = Request.Cookies[InfoKey].Value;
                    strUserInfo = SecurityHelper.DecryptUserInfo(strUserInfo);
                    int userId = int.Parse(strUserInfo);
                    var usr = _accountService.GetById(userId);
                    LoginUser = usr;
                }
            }
            return true;
        }

        internal void LoginOff()
        {
            if (Request.Cookies[InfoKey] != null)
                Response.Cookies[InfoKey].Expires = DateTime.Now;
            if (LoginUser != null)
                LoginUser = null;
        }
    }
}