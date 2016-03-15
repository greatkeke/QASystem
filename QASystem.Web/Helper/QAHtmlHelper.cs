namespace System.Web.Mvc
{
    public static class QAHtmlHelper
    {
        public static HtmlString ScriptFor(this HtmlHelper htmlHelper, string name, string value)
        {
            return new HtmlString(string.Format(" <script id='container' name='{0}' type='text / plain'>{1}</script>", name, value));
        }
    }
}