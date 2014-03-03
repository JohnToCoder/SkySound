using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundDAL;
using SoundModel;
using SoundBLL;
using System.IO;
using System.Data;

namespace SkySound.SoundAdmin
{
    public partial class SoundmanageSong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["name"] != null)
                {
                    // 已登陆   
                    if (!Page.IsPostBack)
                    {
                        BindRP();
                    }
                }
                else
                {
                    // 未登陆
                    Response.Redirect("login.aspx");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
                //Response.Redirect("../error.htm");
            }      
        }
        protected void lbtnDel_Click(object sender, EventArgs s)
        {
            string id = Convert.ToString(((LinkButton)sender).CommandArgument);
            SoundSong ss = new SoundSongManager().selectSongById(id);
            if (File.Exists(ss.Content))
            {
                File.Delete(ss.Content);
            } //删除文件
            else
            {
                showMessage.JsHistory(this, "文件不存在！", -1);
            }
            bool b = new SoundSongManager().deleteSong(id);
            if (b)
            {
                string name = Session["name"].ToString();
                SoundMember m = new SoundMemberManager().selectMemByName(name);
                RepSeatchMemSong.DataSource = new SoundSongManager().selectSongByMemId(m.Id);
                RepSeatchMemSong.DataBind();
            }
            else
            {
                showMessage.JsHistory(this, "未知原因导致删除失败", -1);
                return;
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

            Response.Redirect("~../SoundSearch.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        }
        protected void anp_PageChanged(object sender, EventArgs e)
        {
            BindRP();
        }

        private void BindRP()
        {
            int pagesize = anps.PageSize;
            int pageindex = anps.CurrentPageIndex;

            string name = Session["name"].ToString();
            SoundMember m = new SoundMemberManager().selectMemByName(name);
            LBNames.Text = m.Name;
            LBUserIds.Text = m.UserId;
            LBCreateTimes.Text = m.CreateTime;

            string cond = "memId=" + m.Id;
            anps.RecordCount = new SoundSongManager().SongCount(cond);
            DataTable dt = new SoundSongManager().selectFengYe(pagesize, pageindex, cond);

            if (dt.Rows.Count == 0)
            {
                // 无声音
                emptydatass.Visible = true;
            }
            else
            {
                // 有声音
                emptydatass.Visible = false;
                RepSeatchMemSong.DataSource = dt;
                RepSeatchMemSong.DataBind();
            }
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