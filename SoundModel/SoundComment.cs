using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundModel
{
    public class SoundComment
    {
        private string content;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        private string userId;
        /// <summary>
        /// 评论人昵称
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string songId;
        /// <summary>
        /// 所属歌曲
        /// </summary>
        public string SongId
        {
            get { return songId; }
            set { songId = value; }
        }

        public SoundComment(string content, string userId, string songId)
        {
            this.content = content;
            this.userId = userId;
            this.songId = songId;
        }
    }
}
