using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyFirstWebTest
{
    enum EFilter
    {
        JobName,
        CoName,
        CoSize,
        EFilterMax
    }
    class FilterAction
    {
        public FilterAction(Form1 f)
        {
            m_Form = f;
            m_szContents = new string[(int)EFilter.EFilterMax];
            for (int _i = 0; _i < m_szContents.Length; _i++)
            {
                m_szContents[_i] = "";
            }
        }

        public bool isPass()
        {
            //int _webId = WebElementPool.WEB2_ID;
            string _szCoPattern = @"^((武汉)|(湖北))";
            string _szJobPattern2 = @"((应届)|(实习))";
            const int _cCorpSize = 500;

            string _szCurJobName = m_szContents[(int)EFilter.JobName];
            string _szCurCorpName = m_szContents[(int)EFilter.CoName];
            int _iCurCorpSize = 0;
            if (0 == m_szContents[(int)EFilter.CoSize].Length)
            {
                _iCurCorpSize = _cCorpSize + 1;
            } else
            {
                _iCurCorpSize = int.Parse(m_szContents[(int)EFilter.CoSize]);
            }

            Regex r = new Regex(_szCoPattern);
            //如果是 武汉|湖北 开头的公司，规模小的屏蔽
            if (r.IsMatch(_szCurCorpName))
            {
                if (_cCorpSize > _iCurCorpSize)
                    return false;
            }

            r = new Regex(_szJobPattern2);
            if (r.IsMatch(_szCurJobName))
                return false;

            List<SForbiddenCorp> _fList = ForbiddenCorpManager.instance().getForbiddenCorps();
            //屏蔽指定公司
            foreach (SForbiddenCorp _fc in _fList)
            {
                if (-1 != _szCurCorpName.IndexOf(_fc.szCorpName))
                {
                    return false;
                }
            }

            //m_Form.navigate(_webId, szUrl, 0);
            return true;
        }

        public void setContent(EFilter iPos, string szContent)
        {
            if (iPos >= EFilter.EFilterMax)
                return;

            m_szContents[(int)iPos] = szContent;
        }

        private Form1 m_Form;

        private string[] m_szContents;

    }
}
