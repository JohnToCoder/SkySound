using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoundDAL;
using SoundModel;

namespace SoundBLL
{
    public class SoundMemberManager
    {
        private SoundMemberDAO mdao = null;
        public SoundMemberManager()
        {
            mdao = new SoundMemberDAO();
        }

        #region 添加用户
        public bool addMember(SoundMember add)
        {
            return mdao.addMember(add);
        }
        #endregion

        #region 修改用户信息
        public bool upMember(SoundMember up)
        {
            return mdao.upMember(up);
        }
        #endregion

        #region 删除用户
        public bool deleteMember(string name)
        {
            return mdao.deleteMember(name);
        }
        #endregion

        #region 检查是否重名
        public bool IsExists(string name)
        {
            return mdao.IsExists(name);
        }
        #endregion

        #region 取出用户信息
        public SoundMember selectMemByName(string name)
        {
            return mdao.selectMemByName(name);
        }
        #endregion

        #region 取出用户昵称
        public SoundMember selectMemById(string id)
        {
            return mdao.selectMemById(id);
        }
        #endregion

    }
}
