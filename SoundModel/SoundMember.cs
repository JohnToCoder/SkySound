using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundModel
{
    public class SoundMember
    {
        private string id;
        /// <summary>
        /// id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        /// <summary>
        /// 账号
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string pw;
        /// <summary>
        /// 密码
        /// </summary>
        public string Pw
        {
            get { return pw; }
            set { pw = value; }
        }

        private string userId;
        /// <summary>
        /// 昵称
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string createTime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        public SoundMember()
        {
            //51(aspx)
        }

        public SoundMember(string name, string pw, string userId)
        {
            this.name = name;
            this.pw = pw;
            this.userId = userId;
        }

    }
}
