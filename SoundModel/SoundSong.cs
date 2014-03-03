using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundModel
{
    public class SoundSong
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

        private string category;
        /// <summary>
        /// 类别
        /// </summary>
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        private string name;
        /// <summary>
        /// 歌名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string singer;
        /// <summary>
        /// 歌手名
        /// </summary>
        public string Singer
        {
            get { return singer; }
            set { singer = value; }
        }

        private string content;
        /// <summary>
        /// 内容（地址）
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
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

        private string clickCount;
        /// <summary>
        /// 新闻发表时间
        /// </summary>
        public string ClickCount
        {
            get { return clickCount; }
            set { clickCount = value; }
        }

        private string memId;
        /// <summary>
        /// 创建人
        /// </summary>
        public string MemId
        {
            get { return memId; }
            set { memId = value; }
        }

        public SoundSong() { }

        public SoundSong(string category, string name, string singer, string content, string memId)
        {
            this.category = category;
            this.name = name;
            this.content = content;
            this.memId = memId;
        }
    }
}
