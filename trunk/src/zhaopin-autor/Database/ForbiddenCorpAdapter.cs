using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class ForbiddenCorpAdapter : DatabaseObj
    {
        private const string c_Title = "ForbiddenCorp";

        private const string c_AttrCorpName = "name";

        public ForbiddenCorpAdapter()
        {
            m_AttrValues.Add(c_AttrCorpName, "");
        }

        public ForbiddenCorpAdapter(SForbiddenCorp fc)
        {
            m_AttrValues.Add(c_AttrCorpName, fc.szCorpName);
        }

        protected override void innerPick(ref Object t)
        {
            SForbiddenCorp _fc = (SForbiddenCorp)t;
            m_AttrValues[c_AttrCorpName] = _fc.szCorpName;
        }

        protected override void innerPut(ref Object t)
        {
            SForbiddenCorp _fc = (SForbiddenCorp)t;
            _fc.szCorpName = m_AttrValues[c_AttrCorpName];
        }

        public override string getTitle()
        {
            return c_Title;
        }

        public override DatabaseObj clone()
        {
            ForbiddenCorpAdapter _fca = new ForbiddenCorpAdapter();

            return _fca;
        }
    }
}
