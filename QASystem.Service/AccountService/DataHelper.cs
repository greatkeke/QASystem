namespace QASystem.Service.AccountService
{
    class DataHelper
    {
        /// <summary>
        /// 返回 MD5 加密字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
#pragma warning disable CS0618 // 类型或成员已过时
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
#pragma warning restore CS0618 // 类型或成员已过时
        }
    }
}
