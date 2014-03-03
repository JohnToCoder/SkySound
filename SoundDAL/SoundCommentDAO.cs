using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using SoundModel;

namespace SoundDAL
{
    public class SoundCommentDAO
    {
        private SQLHelper sqlhelper;
        public SoundCommentDAO()
        {
            sqlhelper = new SQLHelper();
        }

        //根据歌曲ID取出评论
        public DataTable SelectBySongId(string songId)
        {
            string cmdText = "select id,userId,createTime,[content] from comment where SongId=@songId";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@songId", songId)
            };
            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            return dt;
        }

        //添加评论
        public bool addComment(SoundComment add)
        {
            bool flag = false;
            string cmdText = "Pr_AddComment";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Content", add.Content),
                new SqlParameter("@UserId", add.UserId),
                new SqlParameter("@SongId",add.SongId)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }//5^1^a^s^p^x
            return flag;
        }
        //删除评论
        public bool deleteComment(string id)
        {
            bool flag = false;
            string cmdText = "Pr_DeleteComment";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id", id),
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
