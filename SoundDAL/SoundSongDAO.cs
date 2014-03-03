using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using SoundModel;
using System.Data;

namespace SoundDAL
{
    public class SoundSongDAO
    {
        private SQLHelper sqlhelper;
        public SoundSongDAO()
        {
            sqlhelper = new SQLHelper();
        }

        //添加歌曲
        public bool addSong(SoundSong add)
        {
            bool flag = false;
            string cmdText = "Pr_AddSong";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Category", add.Category),
                new SqlParameter("@Name", add.Name),
                new SqlParameter("@Singer", add.Singer),
                new SqlParameter("@Content",add.Content),
                new SqlParameter("@MemId",add.MemId)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //修改歌名
        public bool upSong(string id, string newName)
        {
            bool flag = false;
            string cmdText = "Pr_UpSong";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id),
                new SqlParameter("@newName", newName)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //删除歌曲
        public bool deleteSong(string id)
        {
            bool flag = false;
            string cmdText = "Pr_DeleteSong";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //检查歌曲重名
        public bool IsExists(string name, string memId)
        {
            bool flag = false;
            string cmdText = "select * from song where name=@name and memId=@memId";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@name",name),
                new SqlParameter("@memId",memId)
            };
            DataTable dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
        //点击数
        public bool clickCount(string id)
        {
            bool flag = false;
            string cmdText = "Pr_ClickCount";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //通过歌名查找歌曲
        public DataTable selectSongByName(string name)
        {
            string cmdText = "select top 20 category,[name],singer,createTime,clickCount,id from song where [name]=@name order by createTime desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@name", name)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            return dt;
        }
        //通过用户查找歌曲
        public DataTable selectSongByMemId(string memId)
        {
            string cmdText = "select category,[name],singer,createTime,clickCount,memId,id from song where memId=@memId";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@memId", memId)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            return dt;
        }
        //通过种类查找歌曲
        public DataTable selectSongByCategory(string category)
        {
            string cmdText = "select top 10 category,[name],singer,createTime,clickCount,id from song where category=@category order by createTime desc";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@category", category)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            return dt;
        }

        //通过歌曲id查找歌曲地址
        public DataTable selectSongAddressById(string id)
        {
            string cmdText = "select [content] from song where id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            return dt;
        }


        //通过歌曲id查找歌曲
        public SoundSong selectSongById(string id)
        {
            SoundSong s = new SoundSong();
            string cmdText = "select category,[name],[content],singer,createTime,clickCount,memId,id from song where id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            s.Id = dt.Rows[0]["id"].ToString();
            s.Category = dt.Rows[0]["category"].ToString();
            s.Name = dt.Rows[0]["name"].ToString();
            s.Content = dt.Rows[0]["content"].ToString();
            s.Singer = dt.Rows[0]["singer"].ToString();
            s.CreateTime = dt.Rows[0]["createTime"].ToString();
            s.ClickCount = dt.Rows[0]["clickCount"].ToString();
            s.MemId = dt.Rows[0]["memId"].ToString();
            return s;
        }

        //通过歌曲id查找评论
        public DataTable selectCommentById(string id)
        {
            string cmdText = "select userId,createTime,[content] from comment where SongId=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            return dt;
        }

        //热播歌曲(点击率高)
        public DataTable selectHotClickSongs()
        {
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery("Pr_SelectHotClickSongs", CommandType.StoredProcedure);
            return dt;
        }

        //新增会员
        public DataTable selectMember()
        {
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery("Pr_SelectMember", CommandType.StoredProcedure);
            return dt;
        }

        //热评歌曲
        public DataTable selectHotContentSongs()
        {
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery("Pr_SelectHotContentSongs", CommandType.StoredProcedure);
            return dt;
        }

        //新增歌曲
        public DataTable selectNewSongs()
        {
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery("Pr_SelectNewSongs", CommandType.StoredProcedure);
            return dt;
        }

        //分页
        public DataTable selectFengYe(int pagesize, int pageindex, string cond)
        {
            string cmdText = "proc_SplitPage";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@tblName", "song" as object),
                new SqlParameter("@strFields", "category,name,singer,createTime,clickCount,id" as object),
                new SqlParameter("@strOrder", "id" as object),
                new SqlParameter("@strOrderType", "desc" as object),
                new SqlParameter("@PageSize", pagesize as object),
                new SqlParameter("@PageIndex", pageindex as object),
                new SqlParameter("@strWhere", cond as object),
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.StoredProcedure);
            return dt;
        }

        //根据条件计数
        public int SongCount(string cond)
        {
            string sql = "select count(*) from song where ";
            sql = sql + cond;
            return int.Parse(sqlhelper.ExecuteScalar(sql));
        }

        //获取歌曲库类别
        public SoundSongK selectSongK()
        {
            SoundSongK sk = new SoundSongK();
            string cmdText = "select category1,category2,category3,id from songk where id=1";
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, CommandType.Text);
            sk.Category1 = dt.Rows[0]["category1"].ToString();
            sk.Category2 = dt.Rows[0]["category2"].ToString();
            sk.Category3 = dt.Rows[0]["category3"].ToString();
            return sk;
        }

        //歌曲库页类别修改

        public bool upSongK(SoundSongK sk)
        {
            bool flag = false;
            string cmdText = "Pr_UpSongK";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Category1", sk.Category1),
                new SqlParameter("@Category2", sk.Category2),
                new SqlParameter("@Category3", sk.Category3)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
    }
}
