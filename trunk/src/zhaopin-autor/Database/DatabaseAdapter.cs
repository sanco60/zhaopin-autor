using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class DatabaseAdapter
    {
        private DatabaseAdapter()
        {
            m_DatabaseAccesor = DatabaseAccesor.instance();
        }

        public void getDatas(EDatabaseType dType, ref List<Object> list, out int iRest)
        {
            List<DatabaseObj> _objList = new List<DatabaseObj>();
            m_DatabaseAccesor.getDatas(dType, ref _objList, out iRest);

            if (0 == _objList.Count)
                return;

            if (EDatabaseType.EUserAccount == dType)
            {
                foreach(DatabaseObj _obj in _objList)
                {
                    Object _ua = new SUserAccount();
                    
                    _obj.put(ref _ua);
                    list.Add(_ua);
                }
            }
            else if (EDatabaseType.ESearchFactor == dType)
            {
                foreach (DatabaseObj _obj in _objList)
                {
                    Object _ua = new SSearchFactor();

                    _obj.put(ref _ua);
                    list.Add(_ua);
                }
            }
            else if (EDatabaseType.EForbiddenCorp == dType)
            {
                foreach (DatabaseObj _obj in _objList)
                {
                    Object _ua = new SForbiddenCorp();

                    _obj.put(ref _ua);
                    list.Add(_ua);
                }
            }
            return;
        }

        public static DatabaseAdapter instance()
        {
            if (null == s_DatabaseAdapter)
                s_DatabaseAdapter = new DatabaseAdapter();
            return s_DatabaseAdapter;
        }

        //静态成员
        private static DatabaseAdapter s_DatabaseAdapter;

        private DatabaseAccesor m_DatabaseAccesor;

    }    
}

