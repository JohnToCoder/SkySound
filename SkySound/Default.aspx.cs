using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundBLL;
using SoundDAL;

namespace SkySound
{
    public partial class Default1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    lbindexcon.Text = "欢迎来到天籁网！本网站提供各种天然声音，希望您满足您的需要！";
                    Repeater1.DataSource = new SoundSongManager().selectMember();
                    Repeater1.DataBind();
                    RepSelectNewS.DataSource = new SoundSongManager().selectNewSongs();
                    RepSelectNewS.DataBind();
                    RepSelectClickHotS.DataSource = new SoundSongManager().selectHotClickSongs();
                    RepSelectClickHotS.DataBind();
                    //RepSelectCommentHotS.DataSource = new SoundSongManager().selectHotContentSongs();
                    //RepSelectCommentHotS.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                // Response.Redirect("error.htm");
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
                    return strTmp + endWith;
            }
            return oldStr;
        }
    }
}