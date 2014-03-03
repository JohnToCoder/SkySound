using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SoundBLL;
using SoundModel;
using SoundDAL;

namespace SkySound
{
    public partial class SoundPlay1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string id = Request.QueryString["id"];


                    if (id != null)
                    {
                        new SoundSongManager().clickCount(id);
                        SoundSong s = new SoundSongManager().selectSongById(id);
                        SoundMember m = new SoundMemberManager().selectMemById(s.MemId);
                        LBCategory.Text = s.Category;
                        LBClickCount.Text = s.ClickCount;
                        LBCreateTime.Text = s.CreateTime;
                        LBMenId.Text = m.UserId;
                        LBName.Text = s.Name;
                        RepSong.DataSource = new SoundSongManager().selectSongAddressById(id);
                        RepSong.DataBind();
                        RepSelectNewS.DataSource = new SoundSongManager().selectNewSongs();
                        RepSelectNewS.DataBind();//5^1^a^s^p^x
                        //DataTable dt = new SoundCommentManager().SelectBySongId(id);
                        //if (dt.Rows.Count == 0)
                        //{
                        //    // 无评论
                        //    //emptydata.Visible = true;
                        //}
                        //else
                        //{
                        //    // 有评论
                        //    //emptydata.Visible = false;
                        //    //RepComment.DataSource = dt;
                        //    //RepComment.DataBind();
                        //}

                    }
                    else
                    {
                        Response.Redirect("error.htm");
                    }
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
                return oldStr + endWith;//5#1#a#s#p#x
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