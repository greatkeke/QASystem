namespace System.Web.Mvc
{
    public static class QAHtmlHelper
    {
        public static HtmlString ScriptFor(this HtmlHelper htmlHelper, string value)
        {
            return new HtmlString(string.Format(" <script id='container' name='content' type='text / plain'>{0}</script>", value));
        }
    }
}