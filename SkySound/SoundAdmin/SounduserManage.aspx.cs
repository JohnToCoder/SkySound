using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundModel;
using SoundBLL;
using SoundDAL;

namespace SkySound.SoundAdmin
{
    public partial class SounduserManage : System.Web.UI.Page
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
                    Response.Redirect("Login.aspx");
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

            //5*1*a*s*p*x
            string action = DropDownList.SelectedValue;

            if (key == "")
            {
                showMessage.JsHistory(this, "搜索内容不能为空！", -1);
                return;
            }

            Response.Redirect("~/SoundSearch.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        }

        protected void BUserId_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            SoundMember m = new SoundMemberManager().selectMemByName(name);
            m.UserId = TBUserId.Text.Trim().ToString();
            bool b = new SoundMemberManager().upMember(m);
            if (b)
            {
                LBNames.Text = m.Name;
                LBUserIds.Text = m.UserId;
                LBCreateTimes.Text = m.CreateTime;
                showMessage.Js(this, "修改成功", -1);
                return;
            }
            else
            {
                showMessage.Js(this, "修改失败", -1);
                return;
            }

        }

        protected void BPw_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            SoundMember m = new SoundMemberManager().selectMemByName(name);
            if (m.Pw != TBOldPw.Text.Trim().ToString())
            {
                showMessage.Js(this, "旧的密码错误", -1);
                return;
            }
            else
            {
                if (TBNewPw.Text.Trim().ToString() == TBNewPws.Text.Trim().ToString())
                {
                    m.Pw = TBNewPw.Text.Trim().ToString();
                    new SoundMemberManager().upMember(m);
                    showMessage.Js(this, "密码修改成功", -1);
                    return;
                }
                else
                {
                    showMessage.Js(this, "新密码不一致", -1);
                    return;
                }
            }
        }
    }
}


//5%1%a%s%p%x