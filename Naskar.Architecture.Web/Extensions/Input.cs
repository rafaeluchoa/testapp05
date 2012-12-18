namespace Naskar.Architecture.Web.Extensions
{
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.UI;

    public static class InputExtensions
    {
        public class PropertyModel
        {
            // TODO: create the builder
            public bool Required { get; set; }

            public string Label { get; set; }

            public string Id { get; set; }

            public string Name { get; set; }

            public object Value { get; set; }

            public Type Type { get; set; }
        }

        public static MvcHtmlString Input<TModel, TProperty>(
            this HtmlHelper<TModel> html, 
            Expression<Func<TModel, TProperty>> expression,
            string label = "",
            bool required = false)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var value = DataBinder.Eval(html.ViewData.Model, name);
            var type = typeof(TProperty);

            var model = new PropertyModel()
                {
                    Id = name.Replace('.', '_'),
                    Name = name,
                    Label = label,
                    Required = required,
                    Value = value,
                    Type = type
                };

            return html.Partial("_" + type.Name, model);
        }
    }
}
