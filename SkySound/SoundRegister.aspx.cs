using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundBLL;
using SoundModel;
using SoundDAL;
using System.IO;

namespace SkySound
{
    public partial class SoundRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repeater1.DataSource = new SoundSongManager().selectMember();
                Repeater1.DataBind();
            }
        }

        protected void BRegister_Click(object sender, EventArgs e)
        {
            //定义变量
            string tbname = null;
            string tbpwd = null;
            string tbpwds = null;
            string tbvd = null;
            string tbuserid = null;
            string Validate_code = null;
            string Error;
            //赋值
            tbname = TBName.Text.Trim();
            tbpwd = TPWD.Text.Trim();
            tbpwds = TPWDS.Text.Trim();
            tbuserid = TBUserId.Text.Trim();
            tbvd = TVitorD.Text.Trim();

            //验证

            bool bname = new SoundMemberManager().IsExists(tbname);

            if (bname)
            {
                Error = "用户已存在，请换个名字";
                TVitorD.Text = "";
                showMessage.Js(this, Error, -1);
                return;
            }

            if (tbpwd != tbpwds)
            {
                Error = "密码与确认密码不一致";
                TVitorD.Text = "";
                showMessage.Js(this, Error, -1);
                return;
            }

            if (Session["Validate_code"] == null)
            {
                //Error = "验证码出错";
                //kf_cms.Common.ContextHelper.Js(this, Error, -1);
                Response.Redirect("register.aspx");

            }

            Validate_code = Session["Validate_code"].ToString();
            if (Validate_code != tbvd)
            {
                Error = "验证码有误";
                TVitorD.Text = "";
                showMessage.Js(this, Error, -1);
                return;
            }

            //注册

            SoundMember m = new SoundMember();
            m.Name = tbname;
            m.Pw = tbpwd;
            m.UserId = tbuserid;

            bool b = new SoundMemberManager().addMember(m);
            if (b)
            {
                string savePath = Server.MapPath("~/music/");
                string saveName = savePath + tbname;
                Directory.CreateDirectory(saveName);
                
                showMessage.JsHistory(this, "注册成功！！", -1);
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