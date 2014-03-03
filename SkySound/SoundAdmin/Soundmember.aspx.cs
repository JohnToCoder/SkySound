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
    public partial class Soundmember : System.Web.UI.Page
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

            string action = DropDownList.SelectedValue;

            if (key == "")
            {
                showMessage.JsHistory(this, "搜索内容不能为空！", -1);
                return;
            }

            Response.Redirect("~/SoundSearch.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        }
    }
}