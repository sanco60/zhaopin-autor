using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class DatabaseAccesor
    {
        private DatabaseAccesor()
        { }

        public static DatabaseAccesor instance()
        {
            if (null == s_DatabaseAccesor)
                s_DatabaseAccesor = new DatabaseAccesor();
            return s_DatabaseAccesor;
        }

        public void getDatas(EDatabaseType dType, ref List<DatabaseObj> list, out int iRest)
        {
            getDatas(dType, ref list, 0, out iRest);
        }

        public void getDatas(EDatabaseType dType, ref List<DatabaseObj> list, int iStart, out int iRest)
        {
            iRest = 0;

            DatabaseObj _dObj = null;
            if (EDatabaseType.EUserAccount == dType)
            {
                _dObj = new UserAccountAdapter();
            }
            else if (EDatabaseType.ESearchFactor == dType)
            {
                _dObj = new SearchFactorAdapter();
            }
            else if (EDatabaseType.EForbiddenCorp == dType)
            {
                _dObj = new ForbiddenCorpAdapter();
            }
            else
            {
                return;
            }

            string _szFileName = AutorConstPool.DATABASEPATH + _dObj.getTitle() + AutorConstPool.FILE_SUFFIX;
            ConfigFileReader _cfr = new ConfigFileReader(_szFileName);
            if (!_cfr.read())
                return;

            const int _limitedLines = 100;
            List<List<string>> _valueRows = _cfr.getValueRows();
            List<string> _attrNames = _cfr.getAttrNames();
                        
            for (int _i = 0; _i < _valueRows.Count; _i++)
            {
                if (_i < iStart || _valueRows[_i].Count < _attrNames.Count)
                    continue;
                if (_i == _limitedLines)
                {
                    iRest = _valueRows.Count - _i;
                    break;
                }

                DatabaseObj _obj = _dObj.clone();
                if (null == _obj)
                    continue;

                for (int _j = 0; _j < _attrNames.Count; _j++)
                {
                    _obj.setValue(_attrNames[_j], _valueRows[_i][_j]);
                }
                list.Add(_obj);
            }
            return;
        }

        private static DatabaseAccesor s_DatabaseAccesor;
    }
}
