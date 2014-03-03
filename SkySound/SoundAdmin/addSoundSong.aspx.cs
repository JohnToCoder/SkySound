using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoundDAL;
using SoundModel;
using SoundBLL;

namespace SkySound.SoundAdmin
{
    public partial class addSoundSong : System.Web.UI.Page
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

        //protected void BSearch_Click(object sender, EventArgs e)
        //{
        //    string key = TBSearch.Text.Trim();

        //    string action = DropDownList.SelectedValue;

        //    if (key == "")
        //    {
        //        showMessage.JsHistory(this, "搜索内容不能为空！", -1);
        //        return;
        //    }

        //    Response.Redirect("~/search.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        //}

        protected void upButton_Click(object sender, EventArgs e)
        {
            string name = Session["name"].ToString();
            string[] allowExtensions = { ".mp3" };
            int maxLength = 10;
            string savePath = Server.MapPath("../music/") + name + "/";
            string saveName = TBUpName.Text.Trim().ToString() + ".mp3";
            Upload(FileUpload, allowExtensions, maxLength, savePath, saveName);
            SoundMember m = new SoundMemberManager().selectMemByName(name);
            string Name = TBUpName.Text.Trim().ToString();//5_1_a_s_p_x
            string Category = TBUpCategory.Text.Trim().ToString();
            string Singer = TBUpSonger.Text.Trim().ToString();
            string Content = savePath + saveName;
            string MemId = m.Id;
            SoundSong s = new SoundSong();
            s.Name = Name;
            s.Category = Category;
            s.Singer = Singer;
            s.Content = Content;
            s.MemId = MemId;
            new SoundSongManager().addSong(s);
        }

        /// <summary>
        /// 上传文件方法
        /// </summary>
        /// <param name="myFileUpload">上传控件ID</param>
        /// <param name="allowExtensions">允许上传的扩展文件名类型,如：string[] allowExtensions = { ".doc", ".xls", ".ppt", ".jpg", ".gif" };</param>
        /// <param name="maxLength">允许上传的最大大小，以M为单位</param>
        /// <param name="savePath">保存文件的目录，注意是绝对路径,如：Server.MapPath("~/upload/");</param>
        /// <param name="saveName">保存的文件名，如果是""则以原文件名保存</param>
        private void Upload(FileUpload myFileUpload, string[] allowExtensions, int maxLength, string savePath, string saveName)
        {
            // 文件格式是否允许上传
            bool fileAllow = false;


            //检查是否有文件案
            if (myFileUpload.HasFile)
            {
                // 检查文件大小, ContentLength获取的是字节，转成M的时候要除以2次1024
                if (myFileUpload.PostedFile.ContentLength / 1024 / 1024 >= maxLength)
                {
                    showMessage.Js(this, "只能上传小于10M的文件！", -1);
                    return;
                }


                //取得上传文件之扩展名，并转换成小写字母
                string fileExtension = System.IO.Path.GetExtension(myFileUpload.FileName).ToLower();
                string tmp = "";   // 存储允许上传的文件后缀名
                //检查扩展文件名是否符合限定类型
                for (int i = 0; i < allowExtensions.Length; i++)
                {
                    tmp += i == allowExtensions.Length - 1 ? allowExtensions[i] : allowExtensions[i] + ",";
                    if (fileExtension == allowExtensions[i])
                    {
                        fileAllow = true;
                    }
                }


                if (fileAllow)
                {
                    try
                    {
                        string name = Session["name"].ToString();
                        SoundMember m = new SoundMemberManager().selectMemByName(name);
                        string Name = TBUpName.Text.Trim().ToString();
                        bool b = new SoundSongManager().IsExists(Name, m.Id);
                        if (b)
                        {
                            showMessage.JsHistory(this, "歌曲重名请重新输入!", -1);
                            return;
                        }
                        string path = savePath + (saveName == "" ? myFileUpload.FileName : saveName);
                        //存储文件到文件夹
                        myFileUpload.SaveAs(path);
                        showMessage.Js(this, "上传成功", -1);
                        return;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                else
                {
                    showMessage.Js(this, "文件格式不符，可以上传的文件格式为：" + tmp, -1);
                    return;
                }
            }
            else
            {
                showMessage.Js(this, "请选择要上传的文件！", -1);
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

            Response.Redirect("~/SoundSearch.aspx?key=" + Server.UrlEncode(key) + "&action=" + action);
        }

    }
}

///////////5//1//a//s//p//x////////