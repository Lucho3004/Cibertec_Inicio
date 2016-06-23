using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebDeveloper.Helpers
{
    public static class CustomHelper
    {
        public static IHtmlString DisplayPriceStatic(double price) 
        { return new HtmlString(GetHtmlForPrice(price));
        }

        public static IHtmlString DisplayPriceExtension(this HtmlHelper helper, double price)
        { return new HtmlString(GetHtmlForPrice(price));
        }

        private static string GetHtmlForPrice(double price)
        { return price == 0.0 ? "<span>free!!!</span>" : $"<span>{price.ToString()}</span>";
        }

        #region "Fecha"
        public static IHtmlString DisplayDateOrNullExtension(this HtmlHelper helper, DateTime? createdate)
        {
            return new HtmlString(GetDateHtml(createdate));
        }
        public static IHtmlString DisplayDateOrNullStatic( DateTime? createdate)
        {
            return new HtmlString(GetDateHtml(createdate));
        }

        private static string GetDateHtml(DateTime? date)
        {
            return !date.HasValue ? "<span>sin fecha</span>" : $"<span>{ date.Value.ToShortDateString()}</span>";
        }
        #endregion
    }
}
