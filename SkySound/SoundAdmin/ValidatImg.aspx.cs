using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace SkySound.SoundAdmin
{
    public partial class ValidatImg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "0123456789";
            char[] chs = str.ToCharArray();
            Random rand = new Random();

            string validater = "";
            for (int i = 0; i < 4; i++)
            {
                char x = chs[rand.Next(0, chs.Length)];
                validater += x;
            }
            Session["Validate_code"] = validater;
            CreateImage(validater);
        }

        protected void CreateImage(string str)
        {
            int iWidth = str.Length * 11;
            Bitmap img = new Bitmap(iWidth, 20);
            Graphics g = Graphics.FromImage(img);
            g.Clear(Color.White);

            Color[] colors = new Color[] { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Chocolate, Color.Brown, Color.DarkCyan, Color.Purple };
            Random rand = new Random();
            for (int i = 0; i < str.Length; i++)
            {
                Color c = colors[rand.Next(0, colors.Length)];
                Font f = new Font("Courier New", 11);
                Brush b = new System.Drawing.SolidBrush(c);

                //画字符
                g.DrawString(str.Substring(i, 1), f, b, (i * 10) + 1, 1, StringFormat.GenericDefault);
            }

            //描边
            g.DrawRectangle(new Pen(Color.Black), 0, 0, img.Width - 1, img.Height - 1);

            //保存图像到内存
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            Response.Clear();
            Response.ContentType = "image/Jpeg";
            Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            img.Dispose();
        }
    }
}