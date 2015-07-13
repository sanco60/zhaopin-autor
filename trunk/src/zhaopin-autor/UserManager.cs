using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class UserManager
    {
        private UserManager()
        {
            m_uaList = new List<SUserAccount>();
            m_DatabaseAdapter = DatabaseAdapter.instance();
        }

        public static bool init()
        {
            if (null != s_UserManager)
                return false;

            s_UserManager = new UserManager();

            if (!s_UserManager.restore())
                return false;

            return true;
        }

        public static UserManager instance()
        {
            return s_UserManager;
        }

        public SUserAccount getUserAccount()
        {
            if (0 == m_uaList.Count)
                return null;

            return m_uaList[0];
        }

        public bool restore()
        {
            int _rest = 0;
            List<Object> _list = new List<Object>();

            m_DatabaseAdapter.getDatas(EDatabaseType.EUserAccount, ref _list, out _rest);
            if (0 == _list.Count)
                return false;

            m_uaList.Clear();
            foreach(Object _obj in _list)
            {
                m_uaList.Add((SUserAccount)_obj);
            }
           
            return true;
        }

        private static UserManager s_UserManager;

        private List<SUserAccount> m_uaList;

        private DatabaseAdapter m_DatabaseAdapter;
    }
}
