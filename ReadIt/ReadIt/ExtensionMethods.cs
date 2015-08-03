using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadIt
{
    public static class ExtensionMethods
    {
        public static HtmlString ExternalLink(this HtmlHelper helper, string URI, string label)
        {
            var x = string.Format("<a href='{0}'>{1}</a>", URI, label);
            return (HtmlString)helper.Raw(x);
        }
        public static HtmlString ExternalLink(this HtmlHelper helper, string URI, string label, string imageUri)
        {
            var x = string.Format("<a href='{0}'><img src='{1}' alt='{2}' width='100px'></a>", URI, imageUri,label);
            return (HtmlString)helper.Raw(x);
        }
    }
}