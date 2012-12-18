namespace Naskar.Architecture.Web.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    public static class ScriptExtensions
    {
        public static IDisposable BeginScripts(this HtmlHelper helper)
        {
            return new ScriptBlock((WebViewPage)helper.ViewDataContainer);
        }

        public static MvcHtmlString RenderScripts(this HtmlHelper helper)
        {
            return MvcHtmlString.Create(string.Join(Environment.NewLine, ScriptBlock.PageScripts));
        }

        private class ScriptBlock : IDisposable
        {
            private const string ScriptsKey = "scripts";

            private readonly WebViewPage _webPageBase;

            public ScriptBlock(WebViewPage webPageBase)
            {
                this._webPageBase = webPageBase;
                this._webPageBase.OutputStack.Push(new StringWriter());
            }

            public static List<string> PageScripts
            {
                get
                {
                    if (HttpContext.Current.Items[ScriptsKey] == null)
                    {
                        HttpContext.Current.Items[ScriptsKey] = new List<string>();
                    }
                        
                    return (List<string>)HttpContext.Current.Items[ScriptsKey];
                }
            }

            public void Dispose()
            {
                PageScripts.Add(this._webPageBase.OutputStack.Pop().ToString());
            }
        }
    }
}
