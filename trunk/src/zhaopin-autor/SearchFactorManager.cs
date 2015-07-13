using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class SearchFactorManager
    {
        public SearchFactorManager()
        {
            m_sfList = new List<SSearchFactor>();
            m_DatabaseAdapter = DatabaseAdapter.instance();
        }

        public static bool init()
        {
            if (null != s_SearchFactorManager)
                return false;

            s_SearchFactorManager = new SearchFactorManager();
            if (!s_SearchFactorManager.restore())
                return false;

            return true;
        }

        public static SearchFactorManager instance()
        {
            return s_SearchFactorManager;
        }

        public bool restore()
        {
            int _rest = 0;
            List<Object> _list = new List<object>();

            m_DatabaseAdapter.getDatas(EDatabaseType.ESearchFactor, ref _list, out _rest);
            if (0 == _list.Count)
                return false;

            m_sfList.Clear();
            foreach(Object _obj in _list)
            {
                m_sfList.Add((SSearchFactor)_obj);
            }

            return true;
        }

        public List<SSearchFactor> getSearchFactors()
        {
            return m_sfList;
        }

        private static SearchFactorManager s_SearchFactorManager;

        private List<SSearchFactor> m_sfList;

        private DatabaseAdapter m_DatabaseAdapter;
    }
}
