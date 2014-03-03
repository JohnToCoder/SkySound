using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundModel
{
    public class SoundSongK
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

        private string category1;
        /// <summary>
        /// 类1
        /// </summary>
        public string Category1
        {
            get { return category1; }
            set { category1 = value; }
        }

        private string category2;
        /// <summary>
        /// 类2
        /// </summary>
        public string Category2
        {
            get { return category2; }
            set { category2 = value; }
        }

        private string category3;
        /// <summary>
        /// 类3
        /// </summary>
        public string Category3
        {
            get { return category3; }
            set { category3 = value; }
        }

        public SoundSongK()
        {

        }

        public SoundSongK(string category1, string category2, string category3)
        {
            this.category1 = category1;
            this.category2 = category2;
            this.category3 = category3;
        }
    }
}


//5@1@a@s@p@x