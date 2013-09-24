namespace Felice.Mvc
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public static class HtmlExtensions
    {
        public static MvcHtmlString PostLink(
            this HtmlHelper helper,
            string url,
            string text,
            string classes = "")
        {
            const string LinkTag = "<a href=\"#\" {2} onclick=\"javascript:{{ var f = document.createElement('form'); f.style.display = 'none'; this.parentNode.appendChild(f); f.method = 'POST'; f.action = '{0}';var s = document.createElement('input'); s.setAttribute('type', 'hidden'); s.setAttribute('name', 'authenticity_token'); s.setAttribute('value', '2TdxXz3to1h0xqixfQmBPAJoJAQVZsM8/+OhyFVolLQ='); f.appendChild(s);f.submit(); }}\">{1}</a>";

            if (string.IsNullOrEmpty(classes) == false)
            {
                classes = "class=\"" + classes + "\"";
            }

            return new MvcHtmlString(string.Format(LinkTag, url, text, classes));
        }

        public static MvcHtmlString ShowValidationSummary(this HtmlHelper helper, string @class = "flash error")
        {
            if (helper.ViewContext.ViewData.ModelState.IsValid == false)
            {
                return helper.ValidationSummary(false, null, new { @class });    
            }
            
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString Submit(
            this HtmlHelper helper,
            string buttonText,
            string classes = "")
        {
            const string Html = @"<input type=""submit"" value=""{0}"" class=""{1}""";
            return new MvcHtmlString(string.Format(Html, buttonText, classes));
        }
    }
}