namespace Naskar.Architecture.Web.Extensions.AjaxBind
{
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Mvc;

    public class ActionButton
    {
        public string URL { get; set; }

        public string UpdatedId { get; set; }
    }

    public static class ButtonExtensions
    {
        public static MvcHtmlString Button<TModel>(
            this HtmlHelper<TModel> html,
            string id,
            string value, 
            string url, 
            string updateId, 
            Dictionary<string, object> attributes = null)
        {
            // TODO: mudar para usar partial view
            var innerHtml = new StringBuilder("<input ");

            if (attributes == null)
            {
                attributes = new Dictionary<string, object>();
            }

            attributes.Add("type", "button");
            attributes.Add("id", id);
            attributes.Add("value", value);

            foreach (var item in attributes)
            {
                innerHtml.Append(" ");
                innerHtml.Append(item.Key);
                innerHtml.Append("='");
                innerHtml.Append(item.Value);
                innerHtml.Append("'");
            }

            innerHtml.Append(" />");

            return MvcHtmlString.Create(innerHtml.ToString() + html.AjaxBind(id, "click", url, updateId).ToString());
        }
    }
}