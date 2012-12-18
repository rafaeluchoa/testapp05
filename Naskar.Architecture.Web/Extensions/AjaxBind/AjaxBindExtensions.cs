
namespace Naskar.Architecture.Web.Extensions.AjaxBind
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    public class AjaxBindOptions
    {
        public string Id { get; set; }

        public string EventName { get; set; }

        public string URL { get; set; }

        public string UpdateId { get; set; }

        public AjaxBindBuilder Builder { get; set; }
    }

    public class AjaxBindBuilder
    {
    }
    
    public static class AjaxBindExtensions
    {
        public static MvcHtmlString AjaxBind<TModel>(
            this HtmlHelper<TModel> html,
            string id,
            string eventName,
            string url, 
            string updateId)
        {
            return html.Partial(
                "_AjaxBind",
                new AjaxBindOptions()
                {
                    Id = id, 
                    EventName = eventName,
                    URL = url, 
                    UpdateId = updateId
                });
        }

        public static MvcHtmlString AjaxBind<TModel>(
            this HtmlHelper<TModel> html,
            string id,
            string eventName,
            string url, 
            string updateId,
            Action<AjaxBindBuilder> action)
        {
            var builder = new AjaxBindBuilder();

            action(builder);

            return html.Partial(
                "_AjaxBind",
                new AjaxBindOptions()
                {
                    Id = id, 
                    EventName = eventName,
                    URL = url, 
                    UpdateId = updateId,
                    Builder = builder
                });
        }
    }
}