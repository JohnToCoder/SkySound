using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundModel;
using System.Data.SqlClient;
using System.Data;

namespace SoundDAL
{
    public class SoundMemberDAO
    {
        private SQLHelper sqlhelper;
        public SoundMemberDAO()
        {
            sqlhelper = new SQLHelper();
        }

        //添加用户
        public bool addMember(SoundMember add)
        {
            bool flag = false;
            string cmdText = "Pr_AddMember";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Name", add.Name),
                new SqlParameter("@Pw", add.Pw),
                new SqlParameter("@UserId",add.UserId)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //修改用户信息
        public bool upMember(SoundMember up)
        {
            bool flag = false;
            string cmdText = "Pr_UpMember";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@Name", up.Name),
                new SqlParameter("@Pw", up.Pw),
                new SqlParameter("@UserId",up.UserId)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //删除用户
        public bool deleteMember(string name)
        {
            bool flag = false;
            string cmdText = "Pr_DeleteMember";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@name",name)
            };
            int res = (sqlhelper.ExecuteNonQuery(cmdText, paras, CommandType.StoredProcedure));
            if (res > 0)
            {
                flag = true;
            }
            return flag;
        }
        //检查是否重名
        public bool IsExists(string name)
        {
            bool flag = false;
            string cmdText = "select * from member where name=@name";
            SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@name",name)
            };
            DataTable dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
            return flag;
        }
        //取出用户信息
        public SoundMember selectMemByName(string name)
        {
            SoundMember m = new SoundMember();
            string cmdText = "select createTime,name,pw,userId,id from member where name=@name";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@name",name)
            };

            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);
            m.Id = dt.Rows[0]["id"].ToString();
            m.Name = dt.Rows[0]["name"].ToString();
            m.Pw = dt.Rows[0]["pw"].ToString();
            m.UserId = dt.Rows[0]["userId"].ToString();
            m.CreateTime = dt.Rows[0]["createTime"].ToString();

            return m;
        }
        //取出用户昵称
        public SoundMember selectMemById(string id)
        {
            SoundMember m = new SoundMember();
            string cmdText = "select userId from member where id=@id";
            SqlParameter[] paras = new SqlParameter[] {
                new SqlParameter("@id",id)
            };

            DataTable dt = new DataTable();
            dt = sqlhelper.ExecuteQuery(cmdText, paras, CommandType.Text);

            m.UserId = dt.Rows[0]["userId"].ToString();

            return m;
        }
    }
}
