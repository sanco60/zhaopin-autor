using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebTest
{
    class FlashAction
    {
        public FlashAction(Form1 f)
        {
            m_Form = f;
        }

        public bool start()
        {
            int _webId = WebElementPool.WEB1_ID;
            Attribute _aBtnRefresh;

            _aBtnRefresh.szKey = WebElementPool.URL;
            _aBtnRefresh.szValue = "IsRefreshResume";

            string _szSou = "职位搜索";

            //点击刷新
            m_Form.invokeMember(_webId, WebElementPool.A, _aBtnRefresh, WebElementPool.CLICK);

            //点击搜索职位
            m_Form.invokeMember2(_webId, WebElementPool.A, _szSou, WebElementPool.CLICK);
            m_Form.wait(_webId, 0);

            Console.WriteLine("===FlashAction over.===");
            return true;
        }

        private Form1 m_Form;
    }
}
