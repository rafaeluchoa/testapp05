namespace Naskar.Architecture.Web.Extensions
{
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    using Naskar.Architecture.Domain;
    using Naskar.Architecture.Web.Models;

    public static class SelectExtensions
    {
        public static MvcHtmlString ManySelect<TModel, TEntity>(
            this HtmlHelper<TModel> html,
            EntityModel<TEntity> entityModel)
            where TEntity : Entity, new()
        {
            return html.Partial("_ManySelect", entityModel);
        }
    }
}
