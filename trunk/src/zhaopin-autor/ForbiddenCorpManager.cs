using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class ForbiddenCorpManager
    {
        public ForbiddenCorpManager()
        {
            m_fcList = new List<SForbiddenCorp>();
            m_DatabaseAdapter = DatabaseAdapter.instance();
        }

        public static bool init()
        {
            if (null != s_ForbiddenCorpManager)
                return false;

            s_ForbiddenCorpManager = new ForbiddenCorpManager();
            if (!s_ForbiddenCorpManager.restore())
                return false;

            return true;
        }

        public static ForbiddenCorpManager instance()
        {
            return s_ForbiddenCorpManager;
        }

        public bool restore()
        {
            int _rest = 0;
            List<Object> _list = new List<object>();

            m_DatabaseAdapter.getDatas(EDatabaseType.EForbiddenCorp, ref _list, out _rest);
            if (0 == _list.Count)
                return false;

            m_fcList.Clear();
            foreach (Object _obj in _list)
            {
                m_fcList.Add((SForbiddenCorp)_obj);
            }

            return true;
        }

        public List<SForbiddenCorp> getForbiddenCorps()
        {
            return m_fcList;
        }

        private static ForbiddenCorpManager s_ForbiddenCorpManager;

        private List<SForbiddenCorp> m_fcList;

        private DatabaseAdapter m_DatabaseAdapter;
    }
}
