using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundDAL;
using SoundModel;
using SoundBLL;
using System.Web.Security;

namespace SkySound.SoundAdmin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                Repeater1.DataSource = new SoundSongManager().selectMember();
                Repeater1.DataBind();

            }
        }
        protected void BLogin_Click(object sender, EventArgs e)
        {
            //定义变量
            string tbname = null;
            string tbpwd = null;
            string tbvd = null;
            string Validate_code = null;
            string Error;
            //赋值
            tbname = TBName.Text.Trim();
            tbpwd = TPWD.Text.Trim();
            tbvd = TVitorD.Text.Trim();
            //密码加密
            tbpwd = FormsAuthentication.HashPasswordForStoringInConfigFile(tbpwd, "MD5");

            //验证
            if (string.IsNullOrEmpty(tbname) || string.IsNullOrEmpty(tbpwd) || string.IsNullOrEmpty(tbvd))
            {
                Error = "必填信息不能为空";
                showMessage.JsHistory(this, Error, -1);
                return;
            }
            if (Session["Validate_code"] == null)
            {
                //Error = "验证码出错";
                //kf_cms.Common.ContextHelper.Js(this, Error, -1);
                Response.Redirect("Login.aspx");

            }

            Validate_code = Session["Validate_code"].ToString();
            if (Validate_code != tbvd)
            {
                Error = "验证码有误";
                showMessage.JsHistory(this, Error, -1);
                return;

            }
            //登录

            bool bname = new SoundMemberManager().IsExists(tbname);

            if (!bname)
            {
                Error = "用户不存在";
                showMessage.JsHistory(this, Error, -1);
                TVitorD.Text = "";
                return;
            }

            SoundMember m = new SoundMemberManager().selectMemByName(tbname);

            string pw = FormsAuthentication.HashPasswordForStoringInConfigFile(m.Pw, "MD5");
            if (tbpwd == pw)
            {
                Session["name"] = tbname;
                Session.Timeout = 1440;//5+1+a+s+p+x
                if (tbname == "a2610sc")
                {
                    Response.Redirect("Soundmaster.aspx");
                }
                else
                {
                    Response.Redirect("Soundmember.aspx");
                }
            }
            else
            {
                //  Response.Write("error ~!");
                TVitorD.Text = "";
                showMessage.Js(this, "账号或者密码出错", -1);
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

//5|1|a|s|p|x