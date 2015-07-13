using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class ScenarioProcessor
    {
        public ScenarioProcessor(Form1 _f)
        {
            m_Form1 = _f;
            m_LoginAction = new LoginAction(_f);
            m_SearchAction = new SearchAction(_f);
            m_ApplyAction = new ApplyAction(_f);
            m_FlashAction = new FlashAction(_f);
        }

        public void setForm(Form1 _f)
        {
            m_Form1 = _f;
        }

        public Form1 getForm()
        {
            return m_Form1;
        }
        public void start()
        {
            if (null == m_Form1 || null == m_LoginAction)
                return;

            m_LoginAction.start();
            /*m_FlashAction.start();

            List<SSearchFactor> _list = SearchFactorManager.instance().getSearchFactors();
            foreach(SSearchFactor _sf in _list)
            {
                m_SearchAction.setSearchFactor(_sf);
                m_SearchAction.start();
                m_ApplyAction.start();
            }*/

            return;
        }

        private Form1 m_Form1;

        private LoginAction m_LoginAction;

        private SearchAction m_SearchAction;

        private ApplyAction m_ApplyAction;

        private FlashAction m_FlashAction;
    }
}
