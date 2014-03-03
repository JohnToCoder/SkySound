using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundDAL;
using System.Data;
using SoundBLL;

namespace SkySound
{
    public partial class SoundSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                RepSelectNewS.DataSource = new SoundSongManager().selectNewSongs();
                RepSelectNewS.DataBind();
                BindRP();
            }
        }

        protected void BSearch_Click(object sender, EventArgs e)
        {
            string key = TBSearch.Text.Trim();

            string action = DropDownList.SelectedValue;

            if (key == "")
            {
                showMessage.JsHistory(this, "搜索内容不能为空！", -1);
                return;
            }

            Response.Redirect("~/SoundSearch.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        }

        ///   <summary> 
        ///   将指定字符串按指定长度进行剪切， 
        ///   </summary> 
        ///   <param   name= "oldStr "> 需要截断的字符串 </param> 
        ///   <param   name= "maxLength "> 字符串的最大长度 </param> 
        ///   <param   name= "endWith "> 超过长度的后缀 </param> 
        ///   <returns> 如果超过长度，返回截断后的新字符串加上后缀，否则，返回原字符串 </returns> 
        public static string StringTruncat(string oldStr, int maxLength, string endWith)
        {
            if (string.IsNullOrEmpty(oldStr))
                //   throw   new   NullReferenceException( "原字符串不能为空 "); 
                return oldStr + endWith;
            if (maxLength < 1)
                throw new Exception("返回的字符串长度必须大于[0] ");
            if (oldStr.Length > maxLength)
            {
                string strTmp = oldStr.Substring(0, maxLength);
                if (string.IsNullOrEmpty(endWith))
                    return strTmp;
                else
                    return strTmp + endWith;//5|1|a|s|p|x
            }
            return oldStr;
        }

        protected void anp_PageChanged(object sender, EventArgs e)
        {
            BindRP();
        }
        private void BindRP()
        {
            int pagesize = anp.PageSize;
            int pageindex = anp.CurrentPageIndex;

            string key = Server.UrlDecode(Request.QueryString["key"]);

            string action = Request.QueryString["action"];

            if ("category" == action)
            {
                // 按类别搜索 
                string cond = "category=" + "'" + key + "'";
                anp.RecordCount = new SoundSongManager().SongCount(cond);
                DataTable dt = new SoundSongManager().selectFengYe(pagesize, pageindex, cond);
                if (dt.Rows.Count == 0)
                {
                    // 无声音
                    emptydatas.Visible = true;
                }
                else
                {
                    // 有声音
                    emptydatas.Visible = false;
                    RepSelect.DataSource = dt;
                    RepSelect.DataBind();
                }
            }
            else
            {
                // 按名称搜索
                string cond = "[name]=" + "'" + key + "'";
                anp.RecordCount = new SoundSongManager().SongCount(cond);//5_1_a_s_p_x
                DataTable dt = new SoundSongManager().selectFengYe(pagesize, pageindex, cond);
                if (dt.Rows.Count == 0)
                {
                    // 无声音
                    emptydatas.Visible = true;
                }
                else
                {
                    // 有声音
                    emptydatas.Visible = false;
                    RepSelect.DataSource = dt;
                    RepSelect.DataBind();
                }
            }
        }
    }
}