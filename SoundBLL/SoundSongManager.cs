using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SoundModel;
using SoundDAL;

namespace SoundBLL
{
    public class SoundSongManager
    {
        private SoundSongDAO sdao = null;
        public SoundSongManager()
        {
            sdao = new SoundSongDAO();
        }

        #region 添加歌曲
        public bool addSong(SoundSong add)
        {
            return sdao.addSong(add);
        }
        #endregion

        #region 修改歌名
        public bool upSong(string id, string newName)
        {
            return sdao.upSong(id, newName);
        }
        #endregion

        #region 删除歌曲
        public bool deleteSong(string id)
        {
            return sdao.deleteSong(id);
        }
        #endregion

        #region 检查歌曲重名
        public bool IsExists(string name, string memId)
        {
            return sdao.IsExists(name, memId);
        }
        #endregion

        #region 点击数
        public bool clickCount(string id)
        {
            return sdao.clickCount(id);
        }
        #endregion

        #region 通过歌名查找歌曲
        public DataTable selectSongByName(string name)
        {
            return sdao.selectSongByName(name);
        }
        #endregion

        #region 通过用户查找歌曲
        public DataTable selectSongByMemId(string memId)
        {
            return sdao.selectSongByMemId(memId);
        }
        #endregion

        #region 通过种类查找歌曲
        public DataTable selectSongByCategory(string category)
        {
            return sdao.selectSongByCategory(category);
        }
        #endregion

        #region 通过歌曲id查找歌曲地址
        public DataTable selectSongAddressById(string id)
        {
            return sdao.selectSongAddressById(id);
        }
        #endregion

        #region 通过歌曲id查找歌曲
        public SoundSong selectSongById(string id)
        {
            return sdao.selectSongById(id);
        }
        #endregion

        #region 通过歌曲id查找歌曲评论
        public DataTable selectCommentById(string id)
        {
            return sdao.selectCommentById(id);
        }
        #endregion

        #region 热播歌曲(点击率高)
        public DataTable selectHotClickSongs()
        {
            return sdao.selectHotClickSongs();
        }
        #endregion

        #region 新增会员
        public DataTable selectMember()
        {
            return sdao.selectMember();
        }
        #endregion

        #region 热评歌曲
        public DataTable selectHotContentSongs()
        {
            return sdao.selectHotContentSongs();
        }
        #endregion

        #region 新增歌曲
        public DataTable selectNewSongs()
        {
            return sdao.selectNewSongs();
        }
        #endregion

        #region 分页
        public DataTable selectFengYe(int pagesize, int pageindex, string cond)
        {
            return sdao.selectFengYe(pagesize, pageindex, cond);
        }
        #endregion

        #region 计数
        public int SongCount(string cond)
        {
            return sdao.SongCount(cond);
        }
        #endregion

        #region 获取歌曲库类别
        public SoundSongK selectSongK()
        {
            return sdao.selectSongK();
        }
        #endregion

        #region 歌曲库页类别修改
        public bool upSongK(SoundSongK sk)
        {
            return sdao.upSongK(sk);
        }
        #endregion

    }
}
