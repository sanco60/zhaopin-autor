using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class SearchFactorAdapter : DatabaseObj
    {
        private const string c_Title = "SearchFactor";

        private const string c_AttrCatalog = "catalog";
        private const string c_AttrKeytext = "keytext";

        public SearchFactorAdapter()
        {
            m_AttrValues.Add(c_AttrCatalog, "");
            m_AttrValues.Add(c_AttrKeytext, "");
        }

        public SearchFactorAdapter(SSearchFactor s)
        {
            m_AttrValues.Add(c_AttrCatalog, s.eSearchCata.ToString());
            m_AttrValues.Add(c_AttrKeytext, s.szSearchText);
        }

        protected override void innerPick(ref Object t)
        {
            SSearchFactor _sf = (SSearchFactor)t;
            m_AttrValues[c_AttrCatalog] = _sf.eSearchCata.ToString();
            m_AttrValues[c_AttrKeytext] = _sf.szSearchText;
        }

        protected override void innerPut(ref Object t)
        {
            SSearchFactor _sf = (SSearchFactor)t;
            _sf.eSearchCata = (ESearchCata)Enum.Parse(typeof(ESearchCata), m_AttrValues[c_AttrCatalog]);
            _sf.szSearchText = m_AttrValues[c_AttrKeytext];
        }

        public override string getTitle()
        {
            return c_Title;
        }

        public override DatabaseObj clone()
        {
            SearchFactorAdapter _sfa = new SearchFactorAdapter();
            
            return _sfa;
        }
    }
}
