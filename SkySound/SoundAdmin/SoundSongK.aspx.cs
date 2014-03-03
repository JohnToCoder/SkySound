using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundDAL;
using SoundBLL;
using SoundModel;

namespace SkySound.SoundAdmin
{
    public partial class SoundSongK : System.Web.UI.Page
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
                        string name = Session["name"].ToString();
                        SoundMember m = new SoundMemberManager().selectMemByName(name);
                        LBNames.Text = m.Name;
                        LBUserIds.Text = m.UserId;
                        LBCreateTimes.Text = m.CreateTime;
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
        protected void BSearch_Click(object sender, EventArgs e)
        {
            string key = TBSearch.Text.Trim();

            string action = DropDownList.SelectedValue;//5!1!a!s!p!x

            if (key == "")
            {
                showMessage.JsHistory(this, "搜索内容不能为空！", -1);
                return;
            }

            Response.Redirect("~/SoundSearch.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        }

        protected void upButton1_Click(object sender, EventArgs e)
        {
            //string category = TBUp1.Text.Trim().ToString();
            //SoundSongK sk = new SoundSongManager().selectSongK();
            //sk.Category1= category;
            //bool b = new SoundSongManager().SoundupSongK(sk);
            //if (b)
            //{
            //    showMessage.JsHistory(this, "修改成功", -1);
            //    return;
            //}
            //else
            //{
            //    showMessage.JsHistory(this, "修改失败", -1);
            //    return;
            //}
        }

        protected void upButton2_Click(object sender, EventArgs e)
        {
            string category = TBUp2.Text.Trim().ToString();
            //SoundSongK sk = new SoundSongManager().selectSongK();
            //sk.Category2 = category;
            //bool b = new SoundSongManager().upSongK(sk);
            //if (b)
            //{
            //    showMessage.JsHistory(this, "修改成功", -1);
            //    return;
            //}
            //else
            //{
            //    showMessage.JsHistory(this, "修改失败", -1);
            //    return;
            //}
        }

        protected void upButton3_Click(object sender, EventArgs e)
        {
            string category = TBUp3.Text.Trim().ToString();
            ////SoundSongK sk = new SoundSongManager().selectSongK();
            ////sk.Category3 = category;
            ////bool b = new SoundSongManager().upSongK(sk);
            //if (b)
            //{
            //    showMessage.JsHistory(this, "修改成功", -1);
            //    return;
            //}
            //else
            //{
            //    showMessage.JsHistory(this, "修改失败", -1);
            //    return;
            //}
        }
    }
}