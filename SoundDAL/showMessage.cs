using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SoundDAL
{
    public class showMessage
    {
        public static string ErrorStr;
        protected enum action : int
        {
            GoBack = -1, Stay = 2

        }
        public string RequestPar(string name)
        {
            if (Request != null)
            {
                if (Request.QueryString[name] != null)
                {
                    return Request.QueryString[name].Trim();
                }
            }
            return null;
        }

        /// <summary>
        /// 得到当前上下文的“当前”
        /// </summary>
        public static HttpContext Current
        {
            get { return System.Web.HttpContext.Current; }
        }

        /// <summary>
        /// 得到当前上下文的 Request
        /// </summary>
        public static HttpRequest Request
        {
            get { return Current.Request; }
        }
        /// <summary>
        /// 得到当前上下文的 Response
        /// </summary>
        public static HttpResponse Response
        {
            get { return Current.Response; }
        }

        public static void Js(System.Web.UI.Page a, string word, int actionint)
        {
            if (actionint == -1)
                a.RegisterStartupScript("p1", "<script>alert('" + word + "!');</script>");
        }

        public static void JsHistory(System.Web.UI.Page a, string word, int actionint)
        {
            if (actionint == -1)
                a.RegisterStartupScript("p1", "<script>alert('" + word + "!');history.back(-1);</script>");

        }

        public static string Q(string name)
        {
            return Request.QueryString[name] == null ? "" : Request.QueryString[name];
        }
    }
}
